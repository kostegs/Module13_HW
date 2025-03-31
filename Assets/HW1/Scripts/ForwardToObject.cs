using UnityEngine;

public class ForwardToObject : MonoBehaviour
{
    [SerializeField] private GameObject _forwardedObject;
    [SerializeField] private Vector3 _offset;

    private void LateUpdate()
    {
        //transform.localPosition = _forwardedObject.transform.localPosition + _offset;
        //transform.localPosition = _forwardedObject.transform.localPosition + _offset;
        transform.position = _forwardedObject.transform.position + _offset;
        //transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, _forwardedObject.transform.localEulerAngles.y, transform.rotation.z));
        //Debug.Log(_forwardedObject.transform.localRotation);
    }
}
