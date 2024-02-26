using System.Collections;
using HomeWorks._11_2DPlatformer.Sources.Players;
using UnityEngine;

namespace HomeWorks._11_2DPlatformer.Sources.Enemies
{
    public class EnemyAttacker : MonoBehaviour
    {
        [SerializeField] private float _attackSped = 2f;
        [SerializeField] private float _damage;

        private Coroutine _coroutine;
        private WaitForSeconds _waitForSeconds;

        private void Awake() => 
            _waitForSeconds = new WaitForSeconds(_attackSped);

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out Player player))
            {
                StopDealDamage();
                _coroutine = StartCoroutine(DamageRoutine(player));
            }
        }
        private void OnTriggerExit2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out Player player))
            {
                StopDealDamage();
            }
        }

        private IEnumerator DamageRoutine(Player player)
        {
            while (true)
            {
                yield return _waitForSeconds;
                player.TakeDamage(_damage);
            }
        }

        private void StopDealDamage()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
    }
}