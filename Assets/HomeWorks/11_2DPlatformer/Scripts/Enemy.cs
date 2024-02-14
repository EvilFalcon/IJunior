using UnityEngine;

namespace Platformer2D
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Transform _patrol;
        [SerializeField] private float _speed = 1f;

        private Transform[] _points;
        private int _currentPoint;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            SetPoints();
        }

        private void Update()
        {
            Transform target = _points[_currentPoint];

            var direction = (target.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

            if (transform.position == target.position)
            {
                _currentPoint++;

                if (_currentPoint >= _points.Length)
                    _currentPoint = 0;

                _spriteRenderer.flipX = !(_spriteRenderer.flipX);
            }
        }

        private void SetPoints()
        {
            _points = new Transform[_patrol.childCount];

            for (int i = 0; i < _points.Length; i++)
            {
                _points[i] = _patrol.GetChild(i);
            }
        }
    }
}
