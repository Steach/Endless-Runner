using UnityEngine;

public abstract class ActionBase : MonoBehaviour
{
    public abstract void Execute(object data = null);
}
