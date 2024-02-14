using UnityEngine;

namespace GeneratingEnemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _speed = 2f;

        private Vector3 _target;

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        }

        public void SetTarget(Vector3 target)
        {
            _target = target;
        }
    }
}
