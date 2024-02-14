using UnityEngine;

namespace Platformer2D
{
    public class Player : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Apple>(out Apple apple))
                Destroy(apple.gameObject);
        }
    }
}
