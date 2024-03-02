using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HomeWorks.FlappyTerminator.Scripts.Enemys
{
    [Serializable]
    public class Generator : Pool
    {
        [SerializeField] private GameObject _template;
        [SerializeField] private float _secondsBetweenSpawn;
        [SerializeField] private float _maxSpawnPositionY;
        [SerializeField] private float _minSpawnPositionY;
    
        private Coroutine _coroutine;
        private WaitForSeconds _waitForSeconds;

        private void Start()
        {
            Initialize(_template);
            _waitForSeconds = new WaitForSeconds(_secondsBetweenSpawn);
        }

        public void Enable()
        {
            Disable();
        
            _coroutine = StartCoroutine(GenerateEnemy());
        }

        public void Disable()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
        }

        private IEnumerator GenerateEnemy()
        {
            while (true)
            {
                if (TryGetObject(out GameObject enemy))
                {
                    float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
                    Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
                    enemy.SetActive(true);
                    enemy.transform.position = spawnPoint;

                    DisableObjectAbroadScreen();
                }

                yield return _waitForSeconds;
            }
        }
    }
}
