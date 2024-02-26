using System.Collections;
using UnityEngine;

namespace HomeWorks._11_2DPlatformer.Sources.Enemies
{
    [RequireComponent(typeof(EnemyAnimation))]
    public class EnemyWayPointMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _delay;
        [SerializeField] private Transform[] _points;

        private EnemyAnimation _enemyAnimation;
        private WaitForSeconds _waitForSeconds;
        private int _currentPoint;
        private Coroutine _coroutine;

        private void Awake() => 
            _enemyAnimation = GetComponent<EnemyAnimation>();

        private void OnEnable() => 
            _coroutine = StartCoroutine(PatrolRoutine());

        private void Start()
        {
            _currentPoint = 0;
            _waitForSeconds = new WaitForSeconds(_delay);
        }

        private void OnDisable()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }

        private IEnumerator PatrolRoutine()
        {
            while (true)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    _points[_currentPoint].position, 
                    _speed * Time.deltaTime);

                yield return PlayAnimations();
            }
        }

        private IEnumerator PlayAnimations()
        {
            if (transform.position == _points[_currentPoint].position)
            {
                _enemyAnimation.PlayIdle();

                yield return _waitForSeconds;

                _enemyAnimation.PlayMove();
                _enemyAnimation.LookToLeft();
                _currentPoint++;

                if (_currentPoint >= _points.Length)
                {
                    _currentPoint = 0;
                    _enemyAnimation.LookToRight();
                }
            }
        }
    }
}
