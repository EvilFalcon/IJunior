using New_Folder.Sorses;
using UnityEngine;

public class Cube : MovementComponentBase
{
    private Vector3 _vector3;
    [SerializeField, Range(0, 30)] private float _speed;

    private void Awake()
    {
        _vector3 = Vector3.up;
    }

    protected override void Move()
    {
        transform.Rotate(_vector3 * (Time.deltaTime * _speed));
    }
}
