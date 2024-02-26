using System.Collections.Generic;
using UnityEngine;

namespace HomeWorks._09_CodeStyleGenius.Scripts
{
    public class Patrolling : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Transform _placesPoint;
        [SerializeField] private float _minDistance = 0.1f;

        private Vector3 _position;
        private readonly Queue<Transform> _places;
        private Transform _currentPlace;

        private void Awake()
        {
            _position = transform.position;
        }

        private void Start()
        {
            foreach (Transform point in transform)
                _places.Enqueue(point);

            _currentPlace = _places.Dequeue();
        }

        private void Update()
        {
            _position = Vector3.MoveTowards(_position, _currentPlace.position, _speed * Time.deltaTime);

            if (Vector3.Distance(_position, _currentPlace.position) < _minDistance)
                SwitchPlace();
        }

        private void SwitchPlace()
        {
            _places.Enqueue(_currentPlace);
            _currentPlace = _places.Dequeue();
        }
    }
}
