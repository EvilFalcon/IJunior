using HomeWorks._11_2DPlatformer.Sources.Players;
using UnityEngine;

namespace HomeWorks._11_2DPlatformer.Sources.Enemies
{
    public class EnemyPathFindActivator : MonoBehaviour
    {
        [SerializeField] private EnemyWayPointMovement _wayPointMovement;
        [SerializeField] private EnemyMoveToPlayer _moveToPlayer;
        
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out Player player))
            {
                _wayPointMovement.enabled = false;
                _moveToPlayer.SetTarget(player);
                _moveToPlayer.enabled = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out Player player))
            {
                _wayPointMovement.enabled = true;
                _moveToPlayer.SetTarget(player);
                _moveToPlayer.enabled = false;
            }
        }
    }
}