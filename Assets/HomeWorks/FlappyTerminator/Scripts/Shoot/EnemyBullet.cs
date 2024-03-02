using UnityEngine;

namespace HomeWorks.FlappyTerminator.Scripts.Shoot
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class EnemyBullet : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _speed;

        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

            _spriteRenderer.flipX = true;
        }

        private void Update()
        {
            transform.Translate(Vector2.left * (_speed * Time.deltaTime), Space.World);
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
