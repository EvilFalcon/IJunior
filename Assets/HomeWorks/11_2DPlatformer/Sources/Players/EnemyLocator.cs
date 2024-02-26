using System.Collections.Generic;
using HomeWorks._11_2DPlatformer.Sources.Enemies;
using UnityEngine;

namespace HomeWorks._11_2DPlatformer.Sources.Players
{
    public class EnemyLocator : MonoBehaviour
    {
        private List<EnemyHealth> _enemies = new List<EnemyHealth>();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out EnemyHealth enemyHealth))
            {
                _enemies.Add(enemyHealth);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out EnemyHealth enemyHealth))
            {
                _enemies.Remove(enemyHealth);
            }
        }
        
        public EnemyHealth GetClosestEnemy()
        {
            if (_enemies.Count == 0)
            {
                return null;
            }

            float minDistance = float.PositiveInfinity;
            EnemyHealth closestEnemy = null;

            foreach (var enemy in _enemies)
            {
                float distance = Vector2.Distance(transform.position, enemy.transform.position);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestEnemy = enemy;
                }
            }

            return closestEnemy;
        }
        
        public bool Contains(EnemyHealth enemy)
        {
            return _enemies.Contains(enemy);
        }
    }
}
