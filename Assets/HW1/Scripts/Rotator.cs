using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private UserInput _userInput;

    private void Update()
    {
        float rotationAngle = _userInput.MouseMovingX * _rotateSpeed * Time.deltaTime;        

        if (rotationAngle != 0)
            RotateTransformAroundAxis(Vector3.up, rotationAngle);        
    }

    public void RotateTransformAroundAxis(Vector3 axis, float angle)
        => transform.Rotate(axis, angle);    
}
