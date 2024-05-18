using UnityEngine;

public class ExecuteOnPhysics : ExecutorBase
{
    public enum State {Enter, Stay, Exit}

    [SerializeField] private State _state;
    [SerializeField] private bool _onCollision;
    [SerializeField] private bool _onTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (_onTrigger && _state == State.Enter)
        {
            Execute(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_onTrigger && _state == State.Exit)
        {
            Execute(other);
        }
    }

    private void OnTriggerStay (Collider other)
    {
        if (_onTrigger && _state == State.Stay)
        {
            Execute(other);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_onCollision && _state == State.Enter)
        {
            Execute(collision);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (_onCollision && _state == State.Exit)
        {
            Execute(collision);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (_onCollision && _state == State.Stay)
        {
            Execute(collision);
        }
    }
}
