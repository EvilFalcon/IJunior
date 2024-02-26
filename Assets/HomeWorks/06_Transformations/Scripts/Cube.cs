using UnityEngine;

namespace HomeWorks._06_Transformations.Scripts
{
    public class Cube : MovementComponentBase
    {
        [SerializeField, Range(0, 30)] private float _speed;

        protected override void Move()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speed));
        }
    }
}
