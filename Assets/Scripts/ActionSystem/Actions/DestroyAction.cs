using UnityEngine;

public class DestroyAction : ActionBase
{
    public override void Execute(object data = null)
    {
        if (data is GameObject objectToDestroy)
        {
            Destroy(objectToDestroy);
        }

        if (data is Collider collider)
        {
            Destroy(collider.gameObject);
        }

        if (data is Collision collision)
        {
            Destroy(collision.gameObject);
        }
    }
}
