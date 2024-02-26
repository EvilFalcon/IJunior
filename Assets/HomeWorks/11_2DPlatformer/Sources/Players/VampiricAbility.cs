using System.Collections;
using HomeWorks._11_2DPlatformer.Sources.Enemies;
using UnityEngine;

namespace HomeWorks._11_2DPlatformer.Sources.Players
{
    public class VampiricAbility : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private EnemyLocator _enemyLocator;
        [SerializeField] private float _amount;
        [SerializeField] private float _tickDuration;
        [SerializeField] private int _tickAmount;

        private WaitForSeconds _waitForSeconds;
        private Coroutine _routine;

        private void Awake()
        {
            _waitForSeconds = new WaitForSeconds(_tickDuration);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                EnemyHealth closestEnemyHealth = _enemyLocator.GetClosestEnemy();

                if (closestEnemyHealth != null && _routine == null)
                {
                    _routine = StartCoroutine(StealingHealth(closestEnemyHealth));
                }
            }
        }

        private IEnumerator StealingHealth(EnemyHealth enemyHealth)
        {
            for (int i = 0; i < _tickAmount; i++)
            {
                if (enemyHealth.Current <= 0)
                    break;

                if (_enemyLocator.Contains(enemyHealth) == false)
                    break;

                enemyHealth.TakeDamage(_amount);
                _player.Heal(_amount);

                yield return _waitForSeconds;
            }

            _routine = null;
        }
    }
}
