using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    const float SMOOTH_SPEED = 20.0f;
    const float ZOOM_SPEED = 20.0f;

    [SerializeField] private Transform _target;       
    [SerializeField] private LayerMask _collisionMask;

    [SerializeField] private float _minDistance = 1.0f;
    [SerializeField] private float _maxDistance = 5.0f;

    private float _currentDistance;
    private float _initialDistance;

    private void Awake()
    {
        _initialDistance = Vector3.Distance(transform.position, _target.position);        
        _currentDistance = _initialDistance;
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = _target.position - transform.forward * _maxDistance;

        if (Physics.Linecast(_target.position, desiredPosition, out RaycastHit hit, _collisionMask))
            _currentDistance = Mathf.Clamp(hit.distance, _minDistance, _maxDistance);
        else
            _currentDistance = Mathf.Lerp(_currentDistance, _maxDistance, Time.deltaTime * ZOOM_SPEED);

        Vector3 finalPosition = _target.position - transform.forward * _currentDistance;
        transform.position = Vector3.Lerp(transform.position, finalPosition, Time.deltaTime * SMOOTH_SPEED);
        transform.LookAt(_target);        
    }
}
