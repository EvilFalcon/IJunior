using HomeWorks._11_2DPlatformer.Sources.Players;
using UnityEngine;

namespace HomeWorks._11_2DPlatformer.Sources.Items
{
    public class Gem : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Player player))
            {
                Debug.Log("CollisionGemScore");

                gameObject.SetActive(false);
            }
        }
    }
}
