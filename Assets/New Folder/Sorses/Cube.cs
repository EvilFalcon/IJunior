using New_Folder.Sorses;
using UnityEngine;

public class Cube : MovementComponentBase
{
    [SerializeField, Range(0, 30)] private float _speed;

    protected override void Move()
    {
        transform.Rotate(Vector3.up * (Time.deltaTime * _speed));
    }
}
