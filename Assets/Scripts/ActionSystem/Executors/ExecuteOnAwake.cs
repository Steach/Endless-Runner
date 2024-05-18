using UnityEngine;

public class ExecuteOnAwake : ExecutorBase
{
    [SerializeField] private GameObject _object;
    private void Awake()
    {
        Execute(_object);
    }
}
