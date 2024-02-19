using UnityEngine;

namespace Platformer2D
{
    [RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D), typeof(Animator))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;
        [SerializeField] private float _jumpForce = 20f;
        [SerializeField] private float _groundRadius = 0.01f;
        [SerializeField] private Transform _groundChecker;
        [SerializeField] private LayerMask _groundMask;

        private readonly int _moveSpeed = Animator.StringToHash("Speed");

        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rigidbody2D;
        private Animator _animator;
        private bool _isGround;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(_speed * Time.deltaTime, 0, 0);
                _animator.SetFloat(_moveSpeed, _speed);
                _spriteRenderer.flipX = false;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-_speed * Time.deltaTime, 0, 0);
                _animator.SetFloat(_moveSpeed, _speed);
                _spriteRenderer.flipX = true;
            }
            else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
            {
                _animator.SetFloat(_moveSpeed, 0);
            }

            _isGround = Physics2D.OverlapCircle(_groundChecker.position, _groundRadius, _groundMask);

            Debug.Log(_isGround) ;
            
            if (Input.GetKeyDown(KeyCode.Space) && _isGround)
                _rigidbody2D.AddForce(Vector2.up * _jumpForce);
        }
    }
}