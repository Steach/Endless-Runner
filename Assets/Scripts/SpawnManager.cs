using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [Space]
    [Header("Spawn Configuration")]
    [SerializeField] private SpawnInformation _spawnInformation;
    [SerializeField] private float _stepSpawn;
    [SerializeField] private Vector3 _positionToSpawn;
    [Space]
    [Header("Action System")]
    [SerializeField] private ExecutorBase _executor;


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
