using UnityEngine;

public class BoxCheck : MonoBehaviour
{
    [SerializeField] private float _width;
    [SerializeField] private float _height;
    [SerializeField] private LayerMask _collisionMask;

    public bool CheckCollision()
    {
        return Physics2D.OverlapBox(transform.position, new Vector2(_width, _height), 0, _collisionMask);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(_width, _height, 1));
    }
}
