
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private ExecutorBase _executor;
    [SerializeField] private SpawnInformation _spawnInformation;
    [SerializeField] private float _stepSpawn;

    private Vector3 _positionToSpawn;
    

    private void Awake()
    {
        _positionToSpawn = new Vector3(0, 0, _target.position.z);
        _executor.Execute(_spawnInformation);
    }

    private void Update()
    {
        CheckTargetPosition();
    }

    private void CheckTargetPosition()
    {
        if (_positionToSpawn.z <= _target.position.z)
        {
            _positionToSpawn.z += _stepSpawn;
            _spawnInformation._position = _positionToSpawn;
            _executor.Execute(_spawnInformation);
        }
    }
    
    [System.Serializable]
    public struct SpawnInformation
    {
        public Vector3 _position;
        public GameObject _objectToSpawn;
    }
}
