using UnityEngine;

namespace HomeWorks._11_2DPlatformer.Sources.Enemies
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class EnemyAnimation : MonoBehaviour
    {
        private readonly int _idle = Animator.StringToHash("isIdle");
        private readonly int _hurt = Animator.StringToHash("hurt");
        
        private SpriteRenderer _spriteRenderer;
        private Animator _animator;
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void LookToLeft() => 
            _spriteRenderer.flipX = true;

        public void LookToRight() => 
            _spriteRenderer.flipX = false;

        public void PlayIdle() => 
            _animator.SetBool(_idle, true);

        public void PlayMove() => 
            _animator.SetBool(_idle, false);
    }
}