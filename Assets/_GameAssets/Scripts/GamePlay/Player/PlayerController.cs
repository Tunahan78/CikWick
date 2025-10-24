
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance{ set; private get; }
    public static event Action<PlayerState> OnPlayerStateChange;

    private Rigidbody _playerRigidbody;
    [SerializeField] private Transform _oriantation;
    private float horizontalInput;
    private float verticalInput;
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed;
    private float startmoveSpeed;
    [Header("Jump Settings")]
    [SerializeField] private float jumpForce = 5f;
    private float startJumpForce;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [SerializeField] private bool _canJump;
    [SerializeField] private float _jumpCoolDown;

    [Header("Ground Check Settings")]
    [SerializeField] private float _playerHeight;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _grounddamping;

    [Header("Slider Settings")]
    [SerializeField] private KeyCode slideKey = KeyCode.E;
    [SerializeField] private float slideDuration;
    [SerializeField] private float slideCooldown;
    [SerializeField] private float sliderspeed;
    [SerializeField] private float _slidedamping;
    private bool _isSliding = false;
    private bool _canslide = true;
    private float _slideTimer = 0f;
    private float _slideCooldownTimer = 0f;

    private Vector3 _moveDirection;
    private StateController _stateController;
    private PlayerState currentState;


    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        _stateController = GetComponent<StateController>();
        _playerRigidbody = GetComponent<Rigidbody>();
        _playerRigidbody.freezeRotation = true;
        startJumpForce = jumpForce;
        startmoveSpeed = moveSpeed;
    }

    void Update()
    {
        if (GameManager.Instance.GetState() != GameState.Play)
        {
            return;
        } 
        
        SetInput();
        HandleSlideTimer();
        SetPlayerDamping();
        SetState();
    }

    private void SetInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        // zıplama kontrolü

        if (Input.GetKeyDown(jumpKey) && IsGrounded() && _canJump)
        {
            _canJump = false;
            Jump();
            Invoke(nameof(ResetJump), _jumpCoolDown);
        }
        if (Input.GetKeyDown(slideKey) && _canslide && !_isSliding && (horizontalInput != 0 || verticalInput != 0))
        {
            StartSlide();
        }
    }
    private void SetPlayerDamping()
    {
        if (_isSliding)
            _playerRigidbody.linearDamping = _slidedamping;
        else
        {
            _playerRigidbody.linearDamping = _grounddamping;
        }

    }
    private void StartSlide()
    {
        _isSliding = true;
        _canslide = false;
        _slideTimer = slideDuration;
        Debug.Log("Sliding bu nesnede başladı " + gameObject.name);
        // ilerde animasyon eklenebilir
    }
    private void StopSlide()
    {
        _isSliding = false;
        _slideCooldownTimer = slideCooldown;
        Debug.Log("Sliding bu nesnede bitti " + gameObject.name);
    }
    private void HandleSlideTimer()
    {
        if (_isSliding)
        {
            _slideTimer -= Time.deltaTime;
            if (_slideTimer <= 0f)
            {
                StopSlide();
            }
        }
        else if (!_canslide)
        {
            _slideCooldownTimer -= Time.deltaTime;
            if (_slideCooldownTimer <= 0f)
            {
                _canslide = true;
            }
        }
    }

    private void SetState()
    {
        var moveDirection = GetMomentDirection();
        var ısGrounded = IsGrounded();
        var currentController = _stateController.GetCurrentState();

        var newState = currentState switch
        {
            _ when !ısGrounded => PlayerState.Jump,
            _ when moveDirection == Vector3.zero && ısGrounded && !_isSliding => PlayerState.Idle,
            _ when moveDirection != Vector3.zero && ısGrounded && !_isSliding => PlayerState.Move,
            _ when moveDirection == Vector3.zero && ısGrounded && _isSliding => PlayerState.SlideIdle,
            _ when moveDirection != Vector3.zero && ısGrounded && _isSliding => PlayerState.Slide,
            _ => currentState

        };

        if (newState != currentState)
        {
            currentState = newState;
            _stateController.ChangeState(newState);
            OnPlayerStateChange?.Invoke(newState);
        }
        Debug.Log("Current State: " + newState);

    }
    private void SetPlayerMovement()
    {
        _moveDirection = _oriantation.forward * verticalInput + _oriantation.right * horizontalInput;
        if (_isSliding)
        {
            _playerRigidbody.AddForce(_moveDirection.normalized * sliderspeed, ForceMode.Force);
        }
        else
        {
            _playerRigidbody.AddForce(_moveDirection.normalized * moveSpeed, ForceMode.Force);
        }

    }
    private void Jump()
    {
        _playerRigidbody.linearVelocity = new Vector3(_playerRigidbody.linearVelocity.x, 0f, _playerRigidbody.linearVelocity.z);
        _playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        _canJump = true;
    }

    #region Helpers Methos
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, _playerHeight * 0.5f + 0.2f, _groundLayer);
    }
    void FixedUpdate()
    {
        SetPlayerMovement();
    }

    private Vector3 GetMomentDirection()
    {
        return _moveDirection.normalized;
    }

    public float GetCurrentSpeed()
    {
        Vector3 horizontalVelocity = _playerRigidbody.linearVelocity;
        horizontalVelocity.y = 0f;
        return horizontalVelocity.magnitude;
    }

    public void SetMovementSpeed(float speed, float duration)
    {
        moveSpeed += speed;
        Invoke(nameof(ResetMovementSpeed), duration);
    }
    private void ResetMovementSpeed()
    {
        moveSpeed = startmoveSpeed;
    }

    public void SetJumpForce(float force, float duration)
    {
        jumpForce += force;
        Invoke(nameof(ResetJumpForce), duration);
    }
    private void ResetJumpForce()
    {
        jumpForce = startJumpForce;
    }

    public Rigidbody GetPlayerRigidbody()
    {
        return _playerRigidbody;
    }
    #endregion

}
