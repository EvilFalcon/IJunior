using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickListener : MonoBehaviour, IPointerClickHandler
{
    private Vector3 _flagPosition;

    public event Action<Vector3> MapClicked;

    public void OnPointerClick(PointerEventData eventData)
    {
        _flagPosition = eventData.pointerPressRaycast.worldPosition;
        MapClicked?.Invoke(_flagPosition);
    }
}
