using UnityEngine;

public class ResourseSpawner : MonoBehaviour
{
    [SerializeField] private Copper _copperPrefab;

    private float _mapSize = 99f;

    public Copper Spawn()
    {
        Copper copper = Instantiate(_copperPrefab,new Vector3(Random.Range(0f, _mapSize),0,Random.Range(0f, _mapSize)), Quaternion.identity);

        return copper;
    }
}
