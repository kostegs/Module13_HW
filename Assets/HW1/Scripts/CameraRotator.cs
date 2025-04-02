using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private UserInput _userInput;
    [SerializeField] private float _minAngleX;
    [SerializeField] private float _maxAngleX;

    private float xRotation = 0f;
    private float yRotation = 0f;

    private void Update()
    {
        float rotationAngleY = _userInput.MouseMovingX * _rotateSpeed * Time.deltaTime;
        float rotationAngleX = _userInput.MouseMovingY * _rotateSpeed * Time.deltaTime;
        
        RotateTransform(rotationAngleX, rotationAngleY);
    }

    private void RotateTransform(float rotationAngleX, float rotationAngleY)
    {
        yRotation += rotationAngleY;
        xRotation -= rotationAngleX;
        xRotation = Mathf.Clamp(xRotation, _minAngleX, _maxAngleX);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}
