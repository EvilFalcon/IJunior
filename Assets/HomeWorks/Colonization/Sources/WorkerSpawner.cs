using UnityEngine;

public class WorkerSpawner : MonoBehaviour
{
    [SerializeField] private Worker _workerPrefab;

    public Worker Spawn(Vector3 spawnPosition)
    {
        return Instantiate(_workerPrefab, spawnPosition, Quaternion.identity);
    }
}
