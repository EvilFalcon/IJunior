using System.Collections;
using UnityEngine;

namespace HomeWorks._09_CodeStyleGenius.Scripts
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private float _cooldown = 2f;
        [SerializeField] private Bullet _bullet;
        [SerializeField] private Transform _target;

        private WaitForSeconds _sleep;

        private void Awake()
        {
            _sleep = new WaitForSeconds(_cooldown);
        }

        private void Start()
        {
            StartCoroutine(Shoot());
        }

        private IEnumerator Shoot()
        {
            while (enabled)
            {
                var position = transform.position;
                Vector3 targetDirection = (_target.position - position).normalized;
                Bullet bullet = Instantiate(_bullet, position + targetDirection, Quaternion.identity);

                bullet.SetTargetDirection(targetDirection);

                yield return _sleep;
            }
        }
    }
}
