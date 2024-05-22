using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        if (_target != null)
        {
            var targetPosition = new Vector3(transform.position.x, transform.position.y, _target.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, _speed * Time.deltaTime);
        }
    }
}
