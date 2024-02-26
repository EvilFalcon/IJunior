using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HomeWorks._08_GeneratingEnemiesPro.Scripts
{
    public class Target : MonoBehaviour
    {
        [SerializeField] private float _speed = 2f;
        [SerializeField] private float _minDistance = 0.1f;
        [SerializeField] private List<Transform> _points;

        private Transform _currentPoint;

        private void Awake()
        {
            _currentPoint = _points.First();
        }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, _currentPoint.position, _speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _currentPoint.position) < _minDistance)
            {
                _points.Remove(_currentPoint);
                _points.Add(_currentPoint);
                _currentPoint = _points.First();
            }
        }
    }
}
