using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(MeshRenderer))]
public class ColoreChanger : MonoBehaviour
{
    private float _duration = 5f;
    private MeshRenderer _capsulMesh;

    private void Start()
    {
        _capsulMesh = GetComponent<MeshRenderer>();
        _capsulMesh.material.DOColor(Color.red, _duration).SetLoops(-1, LoopType.Yoyo);
    }
}
