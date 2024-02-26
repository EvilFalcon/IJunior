using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ResourseSpawner))]
public class ResourseCollector : MonoBehaviour
{
    [SerializeField] private uint _spawnCount;

    private ResourseSpawner _resourseSpawner;
    private List<Copper> _resourses;
    private float _delayTime = 4f;

    private void Awake()
    {
        _resourses = new List<Copper>();
        _resourseSpawner = GetComponent<ResourseSpawner>();
    }

    private void Start()
    {
        StartCoroutine(AddNewResourses());
    }

    public List<Copper> GiveResourses()
    {
        List<Copper> resourses = new List<Copper>();

        for (int i = 0;i< _resourses.Count; i++)
        {
            resourses.Add(_resourses[i]);
            _resourses.Remove(_resourses[i]);
        }

        return resourses;
    }

    private IEnumerator AddNewResourses()
    {
        WaitForSeconds delay = new WaitForSeconds(_delayTime);

        while (enabled)
        {
            for (int i = 0; i < _spawnCount; i++)
            {
                _resourses.Add(_resourseSpawner.Spawn());
            }

            yield return delay;
        }
    }
}
