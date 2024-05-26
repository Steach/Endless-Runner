using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    [Header("Movement configuration")]
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _horizontalMoveSpeed;
    [SerializeField] private bool running;
    [SerializeField] private float _bounds;
    [Space]
    [Header("Target")]
    [SerializeField] private Rigidbody _targetRB;
    [SerializeField] private Transform _visualTargetTransform;
    [Space]
    [Header("Jump configuration")]
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _mask;

    [SerializeField] private EnegrySliderController _controllerEnergy;
    public bool IsJump { get; private set; }
    public bool IsGameOver { get; private set; }


    private PlayerController _playerController;
    public System.Action FallDownEvent;
    

    private void Awake()
    {
        IsGameOver = false;
        _controllerEnergy.EnergyIsNull += GameOverMethod;
        _playerController = new PlayerController();
        Cursor.lockState = CursorLockMode.Locked;

        _playerController.PlayerMovement.Jump.performed += Jump;
    }
    private void Update() => CheckY();

    private void FixedUpdate()
    {
        if (!IsGameOver)
            Movement();
    }

    private void Movement()
    {
        Vector3 startPos = new Vector3(_targetRB.transform.position.x, _targetRB.transform.position.y + 1f, _targetRB.transform.position.z);
        if (Physics.Raycast(startPos, Vector3.down, 1.2f, _mask))
        {
            IsJump = false;
            _visualTargetTransform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }

        var _movedirection = _playerController.PlayerMovement.Move.ReadValue<Vector2>();

        var velocityBuInput = new Vector3(_movedirection.x, 0f, _movedirection.y) * _horizontalMoveSpeed * Time.fixedDeltaTime;
        _targetRB.velocity = new Vector3(velocityBuInput.x, _targetRB.velocity.y, Run() * Time.deltaTime);

        if(transform.position.x <= -_bounds)
            transform.position = new Vector3(-_bounds, transform.position.y, transform.position.z);
        if(transform.position.x >= _bounds)
            transform.position = new Vector3(_bounds, transform.position.y, transform.position.z);
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (!IsGameOver)
        {
            Vector3 startPos = new Vector3(_targetRB.transform.position.x, _targetRB.transform.position.y + 1f, _targetRB.transform.position.z);
            if (Physics.Raycast(startPos, Vector3.down, 1.2f, _mask))
            {
                _targetRB.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                IsJump = true;
            }
        }        
    }

    private void GameOverMethod() => IsGameOver = true;

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

    private void CheckY()
    {
        if (_targetRB.position.y < -0.1f)
        {
            IsGameOver = true;
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            FallDownEvent?.Invoke();
        } 
    }
}
