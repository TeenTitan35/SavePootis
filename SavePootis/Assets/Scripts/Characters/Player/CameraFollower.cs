using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _smoothing;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var nextPosition = Vector3.Lerp(transform.position, _targetTransform.position + _offset, _smoothing * Time.deltaTime);
        transform.position = nextPosition;
    }
}
