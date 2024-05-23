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

        if (data is SpawnManager.SpawnInformation _spawnInformation)
        {
            if (!_spawnInformation._spawnMoreThanOneObject)
                SpawnOneObject(_spawnInformation._position[0], _spawnInformation._objectToSpawn);

            if (_spawnInformation._spawnMoreThanOneObject)
                SpawnManyObjects(_spawnInformation._transformPositions, _spawnInformation._objectToSpawn);
        }
    }

    private void SpawnOneObject(Vector3 position, GameObject[] gameObjects)
    {
        var obj = gameObjects[Random.Range(0, gameObjects.Length)];
        Instantiate(obj, position, obj.transform.rotation, this.transform);
    }

    private void SpawnManyObjects(Transform[] positions, GameObject[] gameObjects)
    {
        for (int i = 0; i < positions.Length; i++)
        {
            var obj = gameObjects[Random.Range(0, gameObjects.Length)];
            var objRotation = obj.transform.rotation;

            Instantiate(obj, positions[i].position, objRotation, this.transform);
        }   
    }
}
