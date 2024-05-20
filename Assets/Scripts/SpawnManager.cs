using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private ExecutorBase _executor;
    [SerializeField] private SpawnInformation _spawnInformation;
    [SerializeField] private float _stepSpawn;

    [SerializeField] private Vector3 _positionToSpawn;
    

    private void Awake()
    {
        _spawnInformation._position[0] = _positionToSpawn;
        _executor.Execute(_spawnInformation);
    }

    private void Update()
    {
        CheckTargetPosition();
    }

    private void CheckTargetPosition()
    {
        if (_positionToSpawn.z <= _target.position.z + 100)
        {
            _positionToSpawn.z += _stepSpawn;
            _spawnInformation._position[0] = _positionToSpawn;
            _executor.Execute(_spawnInformation);
        }
    }
    
    [System.Serializable]
    public struct SpawnInformation
    {
        public Vector3[] _position;
        public Transform[] _transformPositions;
        public GameObject[] _objectToSpawn;
        public bool _spawnMoreThanOneObject;
    }
}
