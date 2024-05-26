using TMPro;
using UnityEngine;

public class ConditionTag : ConditionBase
{
    [SerializeField] private bool _player;
    [SerializeField] private bool _obstacle;
    [SerializeField] private bool _collectibleItem;
    [SerializeField] private bool _hole;
    public override bool Check(object data = null)
    {
        
        if (data is string _tagData)
        {
            return CheckTag(_tagData);
        }

        if (data is Collider _colliderData)
        {
            var _colliderTag = _colliderData.gameObject.tag;
            return CheckTag(_colliderTag);
        }

        if (data is Collision _collisionData)
        {
            var _collisionTag = _collisionData.gameObject.tag;
            return CheckTag(_collisionTag);
        }

        return false;
    }

    private bool CheckTag(string _tag)
    {
        if (_tag == UIManager.Tags.CollectableItem.ToString() && _collectibleItem)
            return true;
        if (_tag == UIManager.Tags.Obstacle.ToString() && _obstacle)
            return true;
        if (_tag == UIManager.Tags.Player.ToString() && _player)
            return true;
        if (_tag == UIManager.Tags.Hole.ToString() && _hole)
            return true;

        return false;
    }
}
