using UnityEngine;
using DG.Tweening;


public class Rotator : MonoBehaviour
{
    private float _rotateDuration = 5f;

    private void Start()
    {
        transform.DOLocalRotate(new Vector3(0, 180, 0), _rotateDuration).SetLoops(-1,LoopType.Restart) ;
    }
}
