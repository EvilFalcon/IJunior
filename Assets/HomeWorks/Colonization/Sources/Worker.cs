using System;
using UnityEngine;

[RequireComponent(typeof(WorkerMover))]
public class Worker : MonoBehaviour
{
    private bool _isResourseTaken;
    private WorkerMover _workerMover;
    private Transform _basePosition;
    private Transform _resurseForDelivery;
    private Vector3 _localPositionForTaken = new Vector3(0f, 0.5f, 0.5f);
    private Transform _flag;

    public event Action<Worker> ResourseDelivered;
    public event Action<Worker> CameToFlag;

    private void Awake()
    {
        _isResourseTaken = false;
        _workerMover = GetComponent<WorkerMover>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isResourseTaken == true && other.TryGetComponent<Base>(out Base otherBase) && CompareCollision(otherBase))
            GiveResourse();

        if (_isResourseTaken == false && other.TryGetComponent<Copper>(out Copper copper) && CompareCollision(copper))
            PikeUpResourse();

        if (_flag != null && other.TryGetComponent<Flag>(out Flag flag) && CompareCollision(flag))
            BuildBase();
    }

    public bool CompareCollision(Copper foundedResourse)
    {
        bool isOurBase = false;

        if (foundedResourse.transform == _resurseForDelivery)
            isOurBase = true;

        return isOurBase;
    }

    public bool CompareCollision(Base foundedBase)
    {
        bool isOurBase = false;

        if (foundedBase.transform == _basePosition)
            isOurBase = true;

        return isOurBase;
    }

    public bool CompareCollision(Flag foundedFlag)
    {
        bool isOurBase = false;

        if (foundedFlag.transform.position == _flag.position)
            isOurBase = true;

        return isOurBase;
    }

    public void SpecifyBasePosition(Transform basePosition)
    {
        _basePosition = basePosition;
        _workerMover.TakeTarget(_basePosition);
    }

    public void TakeFlagTransform(Transform flag)
    {
        _flag = flag;
        _workerMover.TakeTarget(flag);
    }

    public void TakeResourse(Copper copper)
    {
        _resurseForDelivery = copper.transform;
        _workerMover.TakeTarget(copper.transform);
        _isResourseTaken = false;
    }

    private void PikeUpResourse()
    {
        _resurseForDelivery.SetParent(transform);
        _resurseForDelivery.SetLocalPositionAndRotation(_localPositionForTaken, Quaternion.identity);
        _isResourseTaken = true;
        _resurseForDelivery.GetComponent<Collider>().enabled = false;
        _workerMover.TakeTarget(_basePosition);
    }

    private void GiveResourse()
    {
        Destroy(_resurseForDelivery.gameObject);
        _resurseForDelivery = null;
        ResourseDelivered?.Invoke(this);
        _isResourseTaken = false;
    }

    private void BuildBase()
    {
        CameToFlag?.Invoke(this);
        _flag = null;
    }
}
