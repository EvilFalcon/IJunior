using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    
    private Bird _bird;
    
    private void Update()
    {
        transform.Translate(transform.right * (_speed * Time.deltaTime), Space.Self);
    }

    public void Initialize(Bird bird)
    {
        _bird = bird;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            _bird.IncreaseScore();
            enemy.Die();
            Destroy(gameObject);
        }
    }
}
