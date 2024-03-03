using HomeWorks.FlappyTerminator.Scripts.Enemys;
using UnityEngine;

namespace HomeWorks.FlappyTerminator.Scripts.Shoot
{
    public class PlayerBullet : MonoBehaviour
    {
        private Bird.Bird _bird;
    
        public void Initialize(Bird.Bird bird)
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
}
