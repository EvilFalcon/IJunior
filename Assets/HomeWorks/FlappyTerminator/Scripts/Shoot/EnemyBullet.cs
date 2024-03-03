using UnityEngine;

namespace HomeWorks.FlappyTerminator.Scripts.Shoot
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class EnemyBullet : BaseBullet
    {
        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

            _spriteRenderer.flipX = true;
        }
    
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Bird.Bird bird))
            {
                Destroy(gameObject);
                bird.Die();
            }
        }
    }
}
