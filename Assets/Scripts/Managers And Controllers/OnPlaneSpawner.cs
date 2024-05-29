using UnityEngine;

public class PlaneSpawn : MonoBehaviour
{
    [SerializeField] private SpawnManager.SpawnInformation _spawnInfo;
    [SerializeField] private ExecutorBase _executor;
    [SerializeField] private bool ExecuteOnAwake;
    [SerializeField] private bool ExecuteOnDestroy;

    private void Awake()
    {
        if (ExecuteOnAwake)
            _executor.Execute(_spawnInfo);
    }

    private void OnDestroy()
    {
        if(ExecuteOnDestroy)
            _executor.Execute(_spawnInfo);
    }
}
