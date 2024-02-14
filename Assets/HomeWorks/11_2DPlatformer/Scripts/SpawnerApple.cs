using UnityEngine;

namespace Platformer2D
{
    public class SpawnerApple : MonoBehaviour
    {
        [SerializeField] private Apple _apple;

        private void Start()
        {
            Spawn();
        }

        private void Spawn()
        {
            foreach (Transform spawnPoint in transform)
            {
                Instantiate(_apple, spawnPoint.position, Quaternion.identity);
            }
        }
    }
}
