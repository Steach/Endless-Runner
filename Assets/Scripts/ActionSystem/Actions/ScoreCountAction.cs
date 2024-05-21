using System;
using UnityEngine;

public class ScoreCountAction : ActionBase
{
    public Action ScoreTriggerEvent;

    public override void Execute(object data = null)
    {
        if (data is Collider triggerCollider)
        {
            ScoreTriggerEvent?.Invoke();
        }
    }
}
