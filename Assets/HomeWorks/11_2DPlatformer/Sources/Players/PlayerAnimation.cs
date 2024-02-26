using UnityEngine;

namespace HomeWorks._11_2DPlatformer.Sources.Players
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerAnimation : MonoBehaviour
    {
        private readonly int _run = Animator.StringToHash("isRun");
        private readonly int _jump = Animator.StringToHash("isJump");
        private readonly int _hurt = Animator.StringToHash("hurt");

        private Animator _animator;
        private SpriteRenderer _spriteRenderer;
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void PlayJump() => 
            _animator.SetBool(_jump, true);

        public void StopJump() => 
            _animator.SetBool(_jump, false);

        public void PlayRun() => 
            _animator.SetBool(_run, true);

        public void PlayIdle() => 
            _animator.SetBool(_run, false);

        public void LookToLeft() => 
            _spriteRenderer.flipX = true;

        public void LookToRight() => 
            _spriteRenderer.flipX = false;

        public void PlayHurt() => 
            _animator.SetTrigger(_hurt);
    }
}