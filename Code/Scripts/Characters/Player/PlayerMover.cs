using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(IInputService))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Unit _unit;
    [SerializeField] private BoxCheck _boxCheck;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;

    private IInputService _input;
    private bool _isFacingRight = true;

    private void Start()
    {
        _input = GetComponent<IInputService>();
    }

    private void FixedUpdate()
    {
        ApplyHorizontalMovement();
        ApplyWalkingDirection();
        ApplyJump();
        ApplyAnimation();
    }

    private void ApplyHorizontalMovement()
    {
        var inputX = _input.GetAxis(Axis.X);
        float currentSpeed = _input.GetActionPressed(InputAction.Run) ? _unit.Config.RunSpeed : _unit.Config.WalkSpeed;
        _rigidbody.velocity = new Vector2(inputX * currentSpeed, _rigidbody.velocity.y);
    }

    private void ApplyJump()
    {
        if(_input.GetActionPressed(InputAction.Jump) && IsGrounded())
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _unit.Config.JumpForce);
        }
    }

    private void ApplyWalkingDirection()
    {
        if (_isFacingRight && _input.GetAxis(Axis.X) < 0)
            HandleFlip();
        else if (_isFacingRight == false && _input.GetAxis(Axis.X) > 0)
            HandleFlip();
    }

    private void ApplyAnimation()
    {
        _animator.SetBool(Animations.Walk, _input.GetAxis(Axis.X) != 0);
        _animator.SetBool(Animations.Jump, !IsGrounded());
        _animator.SetFloat(Animations.VerticalVelocity, _rigidbody.velocity.y);
    }

    private void HandleFlip()
    {
        _isFacingRight = !_isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private bool IsGrounded()
    {
        return _boxCheck.CheckCollision();
    }
}
