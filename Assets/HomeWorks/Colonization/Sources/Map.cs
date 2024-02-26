using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FlagSetter))]
[RequireComponent(typeof(ClickListener))]
[RequireComponent(typeof(ResourseCollector))]
[RequireComponent(typeof(WorkerSpawner))]
public class Map : MonoBehaviour
{
    [SerializeField] private Base _basePrefab;
    [SerializeField] private Base _startBase;

    private ResourseCollector _resourseCollector;
    private FlagSetter _flagSetter;
    private ClickListener _clickListener;
    private WorkerSpawner _workerSpawner;
    private List<Base> _bases;
    private Base _currentBase;

    public void Awake()
    {
        _resourseCollector = GetComponent<ResourseCollector>();
        _flagSetter = GetComponent<FlagSetter>();
        _workerSpawner = GetComponent<WorkerSpawner>();
        _clickListener = GetComponent<ClickListener>();
        _bases = new List<Base>();

        InitializeBase(_startBase);
    }

    private void OnEnable()
    {
        AddNewBase(_startBase);
    }

    private void OnDisable()
    {
        foreach (Base currentBase in _bases)
        {
            currentBase.PlayerClicked -= OnPlayerBaseClicked;
            currentBase.WorkerBuiltBase -= OnWorkerBuiltBase;
        }

        _clickListener.MapClicked -= OnMapClicked;
    }

    private void AddNewBase(Base newBase)
    {
        newBase.PlayerClicked += OnPlayerBaseClicked;
        _bases.Add(newBase);
    }

    private void OnPlayerBaseClicked(Base clickedBase)
    {
        _clickListener.MapClicked += OnMapClicked;
        _currentBase = clickedBase;
    }

    private void OnMapClicked(Vector3 flagPosition)
    {
        Transform flag = _flagSetter.ShowFlag(flagPosition, _currentBase.transform.position);
        _currentBase.TakeFlag(flag);
        _currentBase.WorkerBuiltBase += OnWorkerBuiltBase;
    }

    private void OnWorkerBuiltBase(Worker worker, Transform flagPosition, Base baseOfCreater)
    {
        Vector3 basePosition = flagPosition.position;

        _flagSetter.DestroyFlag(baseOfCreater.transform, flagPosition);
        Base newBase = Instantiate(_basePrefab, basePosition, Quaternion.identity);

        InitializeBase(newBase);
        AddNewBase(newBase);
        newBase.AddNewWorker(worker);

        _clickListener.MapClicked -= OnMapClicked;
        baseOfCreater.WorkerBuiltBase -= OnWorkerBuiltBase;
    }

    private void InitializeBase(Base newBase)
    {
        newBase.GetComponent<Scanner>().SetResourseCollector(_resourseCollector);
        newBase.TakeWorkerSpawner(_workerSpawner);
    }
}
