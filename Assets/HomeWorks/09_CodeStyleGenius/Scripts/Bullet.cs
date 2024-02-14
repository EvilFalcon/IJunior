using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 3;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    internal void SetTargetDirection(Vector3 targetDirection)
    {
        _rigidbody.transform.up = targetDirection;
        _rigidbody.velocity = targetDirection * _speed;
    }
}
