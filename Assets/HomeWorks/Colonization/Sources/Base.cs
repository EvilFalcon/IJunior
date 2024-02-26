using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BaseBehaviorChanger))]
[RequireComponent(typeof(Scanner))]
public class Base : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private List<Worker> _startWorkers;
    [SerializeField][Range(0f, 10f)] private float _scanDelayTime;

    private WorkerSpawner _workerSpawner;
    private Scanner _scanner;
    private BaseBehaviorChanger _behaviorChanger;
    private Worker _newBaseBuilder;
    private Transform _flagPosition;
    private Queue<Worker> _freeWorkers;
    private List<Worker> _busyWorkers;
    private Queue<Copper> _resourses;
   [SerializeField] private int _reservedWorkers = 0;
    [SerializeField]private int _copperCount;

    public event Action<Base> PlayerClicked;
    public event Action<Worker, Transform, Base> WorkerBuiltBase;

    private void Awake()
    {
        _freeWorkers = new Queue<Worker>();
        _busyWorkers = new List<Worker>();
        _resourses = new Queue<Copper>();
        _scanner = GetComponent<Scanner>();
        _behaviorChanger = GetComponent<BaseBehaviorChanger>();
    }

    public void Start()
    {
        InitializeStartWorkers();
    }

    private void OnEnable()
    {
        _scanner.ResursesScaned += OnResourseScanned;
    }

    private void OnDisable()
    {
        foreach (Worker worker in _busyWorkers)
            worker.ResourseDelivered -= OnResourseDelivered;

        for (int i = 0; i < _freeWorkers.Count; i++)
            _freeWorkers.Dequeue().ResourseDelivered -= OnResourseDelivered;

        _scanner.ResursesScaned -= OnResourseScanned;
    }

    public void ReserveWorkerForBuldingNewBase(int price)
    {
        if (_copperCount >= price)
            _reservedWorkers = 1;
    }

    public bool TryBuildNewBase(int price)
    {
        bool isWorkerSend = false;

        if (_freeWorkers.Count > 0 && TryPayCopper(price))
        {
            SendWorkerBuildNewBase();
            isWorkerSend = true;
        }

        return isWorkerSend;
    }

    public void SendWorkerBuildNewBase()
    {
        _newBaseBuilder = _freeWorkers.Dequeue();
        _newBaseBuilder.TakeFlagTransform(_flagPosition);
        _newBaseBuilder.CameToFlag += OnWorkerCameToFlag;
        _newBaseBuilder.ResourseDelivered -= OnResourseDelivered;
        _reservedWorkers = 0;
    }

    public bool TryPayCopper(int price)
    {
        bool isPayed = false;

        if (_copperCount >= price)
        {
            _copperCount -= price;
            isPayed = true;
        }

        return isPayed;
    }

    public void TakeFlag(Transform flag)
    {
        _flagPosition = flag;
        _behaviorChanger.SetNewBaseBiuldState();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayerClicked?.Invoke(this);
    }

    public void AddNewWorker(Worker worker)
    {
        _freeWorkers.Enqueue(worker);
        worker.ResourseDelivered += OnResourseDelivered;
        worker.SpecifyBasePosition(transform);
    }

    public void SpawnWorker()
    {
        AddNewWorker(_workerSpawner.Spawn(transform.position));
    }

    public void TakeWorkerSpawner(WorkerSpawner workerSpawner)
    {
        _workerSpawner = workerSpawner;
    }

    private void InitializeStartWorkers()
    {
        foreach (Worker worker in _startWorkers)
        {
            AddNewWorker(worker);
        }

        _startWorkers.Clear();
    }

    private void SendWorkers()
    {
        while (_freeWorkers.Count > _reservedWorkers && _resourses.Count > 0)
        {
            Worker worker = _freeWorkers.Dequeue();
            worker.TakeResourse(_resourses.Dequeue());
            _busyWorkers.Add(worker);
        }
    }

    private void OnResourseScanned(List<Copper> scannedResourses)
    {
        for (int i = 0; i < scannedResourses.Count; i++)
        {
            if (scannedResourses[i] != null)
                _resourses.Enqueue(scannedResourses[i]);
        }

        SendWorkers();
    }

    private void OnResourseDelivered(Worker worker)
    {
        _copperCount++;
        _freeWorkers.Enqueue(worker);
        _busyWorkers.Remove(worker);

        SendWorkers();
    }

    private void OnWorkerCameToFlag(Worker worker)
    {
        _behaviorChanger.SetWorkerBuildState();
        WorkerBuiltBase?.Invoke(worker, _flagPosition, this);
        worker.CameToFlag -= OnWorkerCameToFlag;
    }
}
