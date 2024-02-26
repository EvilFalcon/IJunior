using HomeWorks._11_2DPlatformer.Sources.Items;
using UnityEngine;

namespace HomeWorks._11_2DPlatformer.Sources.Players
{
    [RequireComponent(typeof(PlayerAnimation))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private PlayerAnimation _playerAnimation;
    
        private void Awake() => 
            _playerAnimation = GetComponent<PlayerAnimation>();

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Surfece surface))
            {
                _playerAnimation.StopJump();
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Surfece surface))
            {
                _playerAnimation.PlayJump();
            }
        }

        private void Update()
        {
            if(TryPlayIdle())
                _playerAnimation.PlayIdle();
        
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(_speed * Time.deltaTime, 0, 0);

                _playerAnimation.LookToRight();
                _playerAnimation.PlayRun();
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(_speed * Time.deltaTime * -1, 0, 0);

                _playerAnimation.LookToLeft();
                _playerAnimation.PlayRun();
            }

            if (Input.GetKey(KeyCode.Space))
            {
                transform.Translate(0, _speed * Time.deltaTime, 0);
            }
        }

        private bool TryPlayIdle()
        {
            return Input.GetKey(KeyCode.D) == false &&
                   Input.GetKey(KeyCode.A) == false &&
                   Input.GetKey(KeyCode.Space) == false;
        }
    }
}
