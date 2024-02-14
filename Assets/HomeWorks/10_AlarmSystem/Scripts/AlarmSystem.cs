using UnityEngine;
using UnityEngine.Events;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private UnityEvent _eventEnter;
    [SerializeField] private UnityEvent _eventExit;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
            _eventEnter.Invoke();
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
            _eventExit.Invoke();
    }
}
