using UnityEngine;

public class WorkerMover : MonoBehaviour
{
    [SerializeField][Range(1f, 20f)] private float _speed;

    private float _minDistanse = 0.3f;
    private Transform _target;

    void Update()
    {
        if (Vector3.Distance(transform.position, _target.position) > _minDistanse)
            Move(_target.position);
    }

    public void TakeTarget(Transform target)
    {
        _target = target;
    }

    private void Move(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }
}
