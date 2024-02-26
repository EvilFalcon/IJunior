using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private EnemyBullet _bullet;
    [SerializeField] private float _secondsBetweenSpawn;
    
    private Coroutine _coroutine; 
    private WaitForSeconds _waitForSeconds;
    
    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_secondsBetweenSpawn);
    }

    private void OnEnable()
    {
        _coroutine = StartCoroutine(Shoot());
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator Shoot()
    {
        while (gameObject.activeSelf)
        {
            yield return _waitForSeconds;

            Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
        } 
    }
}
