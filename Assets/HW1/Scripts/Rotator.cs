using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    public void Rotate()
        => transform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);

    private void Update()
    {
        Rotate();
    }

    //
}
