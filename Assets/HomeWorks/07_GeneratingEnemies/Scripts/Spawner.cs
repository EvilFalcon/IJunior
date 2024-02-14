using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneratingEnemies
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private float _respawnTime = 2f;
        [SerializeField] private int _count = 5;
        [SerializeField] private List<Transform> _points;
        [SerializeField] private Enemy _prefab;
        [SerializeField] private Transform _pointCollection;

        private void Start()
        {
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            var waitTime = new WaitForSeconds(_respawnTime);

            for (int i = 0; i < _count; i++)
            {
                Transform spawnPoint = _points[Random.Range(0, _points.Count)];

                Enemy enemy = Instantiate(_prefab, spawnPoint.position, Quaternion.identity);
                enemy.SetTarget(_pointCollection.position);

                yield return waitTime;
            }
        }
    }
}
