using UnityEngine;

namespace HomeWorks.FlappyTerminator.Scripts.Enemys
{
    public class Enemy : MonoBehaviour
    {
        public void Die()
        {
            gameObject.SetActive(false);
        }
    }
}
