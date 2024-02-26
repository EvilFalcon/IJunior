using UnityEngine;

namespace HomeWorks._06_Transformations.Scripts
{
    public class Capsule : MovementComponentBase
    {
        [SerializeField] private Vector3 _targetScale;
        [SerializeField, Range(0.1f, 1)] private float _speed;


        protected override void Move()
        {
            SetScale(_targetScale);
        }

        private void SetScale(Vector3 target)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, target, Time.deltaTime * _speed);
        }
    }
}