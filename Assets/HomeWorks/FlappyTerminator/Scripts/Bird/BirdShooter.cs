using HomeWorks.FlappyTerminator.Scripts.Shoot;
using UnityEngine;

namespace HomeWorks.FlappyTerminator.Scripts.Bird
{
    public class BirdShooter : MonoBehaviour
    {
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private PlayerBullet _bullet;
        [SerializeField] private Bird _bird;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot(_shootPoint);
            }
        }

        public void Shoot(Transform shootPoint)
        {
            PlayerBullet bullet = Instantiate(_bullet, shootPoint.position, Quaternion.identity);
            bullet.Initialize(_bird);
            bullet.transform.rotation = _shootPoint.rotation;
        }
    }
}
