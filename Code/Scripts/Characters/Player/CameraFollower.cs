using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothing;
    [SerializeField] private Vector3 _offset;

    private void FixedUpdate()
    {
        var nextPosition = Vector3.Lerp(transform.position, _target.position + _offset, _smoothing);
        transform.position = nextPosition;
    }
}
