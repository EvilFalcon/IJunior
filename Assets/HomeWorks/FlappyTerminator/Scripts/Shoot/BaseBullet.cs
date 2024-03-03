using UnityEngine;

namespace HomeWorks.FlappyTerminator.Scripts.Shoot
{
    public abstract class BaseBullet : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _speed;
        
        private void Update()
        {
            transform.Translate(transform.right * (_speed * Time.deltaTime), Space.Self);
        }
    }
}