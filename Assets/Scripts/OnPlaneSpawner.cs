using UnityEngine;

public class PlaneSpawn : MonoBehaviour
{
    [SerializeField] private SpawnManager.SpawnInformation _spawnInfo;
    [SerializeField] private ExecutorBase _executor;

    private void Awake()
    {
        _executor.Execute(_spawnInfo);
    }
}
