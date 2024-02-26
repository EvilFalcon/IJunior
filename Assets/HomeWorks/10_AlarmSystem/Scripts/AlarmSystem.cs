using UnityEngine;

namespace HomeWorks._10_AlarmSystem.Scripts
{
    public class AlarmSystem : MonoBehaviour
    {
        [SerializeField] private Siren _siren;

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent<Player>(out Player player))
                _siren.UpVolume();
        }

        private void OnTriggerExit(Collider collider)
        {
            if (collider.TryGetComponent<Player>(out Player player))
                _siren.DownVolume();
        }
    }
}
