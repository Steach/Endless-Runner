using System;
using UnityEngine;

public class ExecutorOnPhysics : ExecutorBase
{
    public enum State { Enter, Exit, Stay }
    public Action TriggerEvent;

    [SerializeField] private State _state;
    [SerializeField] private bool _onTrigger;
    [SerializeField] private bool _onCollision;

    private void OnTriggerEnter(Collider other)
    {
        if (_state == State.Enter && _onTrigger)
        {
            TriggerEvent?.Invoke();
            Execute(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_state == State.Exit && _onTrigger)
        {
            TriggerEvent?.Invoke();
            Execute(other);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_state == State.Stay && _onTrigger)
        {
            TriggerEvent?.Invoke();
            Execute(other);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if (_state == State.Enter && _onCollision)
        {
            Debug.Log("Collision Enter OnCollision");
            Execute(collision);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (_state == State.Exit && _onCollision)
        {
            Execute(collision);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (_state == State.Stay && _onCollision)
        {
            Execute(collision);
        }
    }
}
