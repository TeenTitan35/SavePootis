using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _jumpForce;

    private bool _isFacingRight = true;

    private Rigidbody2D _rb;
    private GroundCheck _isGrounded;
    private Animator _animator;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _isGrounded = GetComponentInChildren<GroundCheck>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? _runSpeed : _walkSpeed;
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

        transform.position += movement * currentSpeed * Time.deltaTime;
        HandleAnimation("isWalking", moveHorizontal != 0 && _isGrounded.CheckGround());

        if (_isFacingRight && Input.GetAxis("Horizontal") < 0)
            HandleFlip();
        else if (_isFacingRight == false && Input.GetAxis("Horizontal") > 0)
            HandleFlip();
    }

    private void Jump()
    {
        HandleAnimation("isJumping", !_isGrounded.CheckGround());
        
        if (Input.GetAxis("Jump") > 0 && _isGrounded.CheckGround())
        {
            _rb.velocity = Vector3.up * _jumpForce;
        }
    }

    private void HandleAnimation(string name, bool state)
    {
        _animator.SetBool(name, state);
    }

    private void HandleFlip()
    {
        _isFacingRight = !_isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}