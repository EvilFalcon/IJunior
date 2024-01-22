using New_Folder.Sorses;
using UnityEngine;

public class Sphere : MovementComponentBase
{
    [SerializeField, Range(0, 3)] private float _speed;

    protected override void Move()
    {
        transform.Translate(Vector3.forward * (_speed * Time.deltaTime));
    }
}