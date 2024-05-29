
using System.Collections;
using UnityEngine;

public class BrokenObstacleBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float _force;
    private void Awake()
    {
        rb.AddForce(Vector3.fwd * _force, ForceMode.Impulse);
        StartCoroutine(DestroyAfterTime());
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
