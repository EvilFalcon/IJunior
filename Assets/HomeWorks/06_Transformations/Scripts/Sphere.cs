using UnityEngine;

namespace HomeWorks._06_Transformations.Scripts
{
    public class Sphere : MovementComponentBase
    {
        [SerializeField, Range(0, 3)] private float _speed;

        protected override void Move()
        {
            transform.Translate(Vector3.forward * (_speed * Time.deltaTime));
        }
    }
}