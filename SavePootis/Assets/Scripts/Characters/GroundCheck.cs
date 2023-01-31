using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private LayerMask _collisionMask;

    public bool CheckGround()
    {
        return Physics2D.OverlapCircle(transform.position, _groundCheckRadius, _collisionMask);
    }
}
