using System.Collections.Generic;
using UnityEngine;

public class FlagSetter : MonoBehaviour
{
    [SerializeField] private GameObject _flagPrefab;

    private Dictionary<Vector3, GameObject> _baseFlags;

    private void Start()
    {
        _baseFlags = new Dictionary<Vector3, GameObject>();
    }

    public Transform ShowFlag(Vector3 flagPosition, Vector3 currentBasePosition)
    {
        GameObject flag;

        if (_baseFlags.ContainsKey(currentBasePosition))
        {
            MoveFlag(flagPosition, _baseFlags[currentBasePosition]);
            flag = _baseFlags[currentBasePosition];
        }
        else
        {
            flag = CreatFlag(flagPosition);
            _baseFlags.Add(currentBasePosition, flag);
        }

        return flag.transform;
    }

    public void DestroyFlag(Transform currentBase, Transform flag)
    {
        Destroy(flag.gameObject);
        _baseFlags.Remove(currentBase.position);
    }

    private GameObject CreatFlag(Vector3 flagPosition)
    {
        return Instantiate(_flagPrefab, flagPosition, Quaternion.identity);
    }

    private void MoveFlag(Vector3 newFlagPosition, GameObject flag)
    {
        flag.transform.position = newFlagPosition;
    }
}
