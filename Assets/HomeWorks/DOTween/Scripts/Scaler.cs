using UnityEngine;
using DG.Tweening;

public class Scaler : MonoBehaviour
{
    private float _duration = 5f;
    private float _endScale = 3f;

    private void Start()
    {
        transform.DOScale(new Vector3(_endScale, _endScale, _endScale), _duration).SetLoops(-1, LoopType.Yoyo);
    }
}
