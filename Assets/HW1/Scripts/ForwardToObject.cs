using UnityEngine;

public class ForwardToObject : MonoBehaviour
{
    [SerializeField] private GameObject _forwardedObject;
    [SerializeField] private Vector3 _offset;

    private void LateUpdate()
        => transform.position = _forwardedObject.transform.position + _offset;
}
