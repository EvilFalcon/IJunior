using HomeWorks._11_2DPlatformer.Sources.Enemies;
using UnityEngine;

namespace HomeWorks._11_2DPlatformer.Sources.Players
{
    public class PlayerAtacker : MonoBehaviour
    {
        [SerializeField] private int _damage = 1;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out EnemyHealth enemyHealth))
            {
                enemyHealth.TakeDamage(_damage);
            }
        }
    }
}
