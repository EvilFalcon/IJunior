using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeWorks._08_GeneratingEnemiesPro.Scripts
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private float _respawnTime = 2f;
        [SerializeField] private int _count = 5;
        [SerializeField] private List<SpawnPoint> _points;

        private void Start()
        {
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            var waitTime = new WaitForSeconds(_respawnTime);

            for (int i = 0; i < _count; i++)
            {
                SpawnPoint spawnPoint = _points[Random.Range(0, _points.Count)];
                spawnPoint.Spawn();

                yield return waitTime;
            }
        }
    }
}
