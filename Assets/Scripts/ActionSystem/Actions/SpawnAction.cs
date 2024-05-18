using UnityEngine;

public class SpawnAction : ActionBase
{
    public override void Execute(object data = null)
    {
        if (data is GameObject _objectToSpawn)
        {
            var _position = new Vector3(0, 0, 10);
            Instantiate(_objectToSpawn, _position, Quaternion.identity, this.transform);
        }

        if (data is SpawnManager.SpawnInformation _spawnOnformation)
        {
            var _spawnPosition = _spawnOnformation._position;
            var _objectToSapwn = _spawnOnformation._objectToSpawn;

            Instantiate(_objectToSapwn, _spawnPosition, Quaternion.identity, this.transform);
        }
    }
}
