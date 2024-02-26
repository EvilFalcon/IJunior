using System.Collections;
using HomeWorks._11_2DPlatformer.Sources.Players;
using UnityEngine;

namespace HomeWorks._11_2DPlatformer.Sources.Enemies
{
    [RequireComponent(typeof(EnemyAnimation))]
    public class EnemyMoveToPlayer : MonoBehaviour
    {
        [SerializeField] private float _delta = 5;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private EnemyAnimation _enemyAnimation;
        private Player _target;

        private Coroutine _coroutine;

        private void Awake() => 
            _enemyAnimation = GetComponent<EnemyAnimation>();

        private void OnEnable() => 
            Follow();

        private void OnDisable() => 
            StopFollow();

        public void SetTarget(Player target) => 
            _target = target;

        private void Follow() => 
            _coroutine = StartCoroutine(Move());

        private void StopFollow()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }

        private IEnumerator Move()
        {
            while(true)
            {
                Vector3 currentPosition = transform.position;
                
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    _target.transform.position, 
                    _delta * Time.deltaTime);
                
                _enemyAnimation.PlayMove();

                if (currentPosition.x < transform.position.x)
                    _enemyAnimation.LookToLeft();
                
                if (currentPosition.x > transform.position.x)
                    _enemyAnimation.LookToRight();
                
                yield return null;
            }
        }
    }
}