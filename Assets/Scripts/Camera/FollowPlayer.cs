using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private float _bound;
    [SerializeField] private Vector3 _offset;

    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        if (_target != null)
        {
            var targetPosition = new Vector3(_target.position.x + _offset.x, 
                transform.position.y + _offset.y, 
                _target.position.z + _offset.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, _speed * Time.deltaTime);
        }

        if (transform.position.x <= -_bound)
            transform.position = new Vector3(-_bound, transform.position.y, transform.position.z);
        if (transform.position.x >= _bound)
            transform.position = new Vector3(_bound, transform.position.y, transform.position.z);
    }
}
