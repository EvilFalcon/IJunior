using New_Folder.Sorses;
using UnityEngine;

public class Capsule : MovementComponentBase
{
    [SerializeField] private Vector3 _targetScale;
    [SerializeField, Range(0.1f, 1)] private float _speed;
    private Vector3 _defaultScale;

    private void Awake()
    {
        _defaultScale = transform.localScale;
    }

    protected override void Move()
    {
        if (_targetScale.y + float.Epsilon > float.Epsilon + transform.localScale.y)
        {
            SetScale(_defaultScale);
            return;
        }

        SetScale(_targetScale);
        
    }

    private void SetScale(Vector3 target)
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, target, Time.deltaTime * _speed);
    }
}