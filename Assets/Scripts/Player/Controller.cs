using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    [Header("Movement configuration")]
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _horizontalMoveSpeed;
    [SerializeField] private bool running;
    [Space]
    [Header("Target")]
    [SerializeField] private Rigidbody _targetRB;
    [Space]
    [Header("Jump configuration")]
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _mask;

    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = new PlayerController();
        Cursor.lockState = CursorLockMode.Locked;

        _playerController.PlayerMovement.Jump.performed += Jump;
    }

    private void FixedUpdate()
    {
        SideMovement();
    }

    private void SideMovement()
    {
        var _movedirection = _playerController.PlayerMovement.Move.ReadValue<Vector2>();

        var velocityBuInput = new Vector3(_movedirection.x, 0f, _movedirection.y) * _horizontalMoveSpeed * Time.fixedDeltaTime;
        _targetRB.velocity = new Vector3(velocityBuInput.x, _targetRB.velocity.y, Run() * Time.deltaTime);
    }

    private void Jump(InputAction.CallbackContext context)
    {
        Vector3 startPos = new Vector3(_targetRB.transform.position.x, _targetRB.transform.position.y + 1f, _targetRB.transform.position.z);
        if (Physics.Raycast(startPos, Vector3.down, 1.2f, _mask))
            _targetRB.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    private float Run()
    {
        if (running)
            return _runSpeed;
        else
            return 0;
    }

    private void OnEnable()
    {
        _playerController.Enable();
    }

    private void OnDisable()
    {
        _playerController.Disable();
    }
}