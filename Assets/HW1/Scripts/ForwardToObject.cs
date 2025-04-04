using UnityEngine;

public class ForwardToObject : MonoBehaviour
{
    [SerializeField] private Transform _target;
    
    private void LateUpdate()
        => transform.position = _target.position;
}
