using System;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    private const string HORIZONTAL_AXIS_NAME = "Horizontal";
    private const string VERTICAL_AXIS_NAME = "Vertical";
    private const string MOUSE_X_AXIS_NAME = "Mouse X";
    private const string MOUSE_Y_AXIS_NAME = "Mouse Y";
    private const KeyCode JUMP_KEY = KeyCode.Space;

    private float _horizontalInput;
    private float _verticalInput;
    private float _mouseMovingX;
    private float _mouseMovingY;
    private bool _jumpKeyPressed;

    public float HorizontalInput => _horizontalInput;
    public float VerticalInput => _verticalInput;
    public bool JumpKeyPressed => _jumpKeyPressed;
    public float MouseMovingX => _mouseMovingX;
    public float MouseMovingY => _mouseMovingY;
    
    void Update()
    {
        CheckHorizontalInput();
        CheckVerticalInput();
        CheckJumpKeyPressed();
        CheckMouseMoving();
    }

    private void CheckMouseMoving()
    {
        _mouseMovingX = Input.GetAxis(MOUSE_X_AXIS_NAME);
        _mouseMovingY = Input.GetAxis(MOUSE_Y_AXIS_NAME);        
    }

    private void CheckJumpKeyPressed()
        => _jumpKeyPressed = Input.GetKeyDown(JUMP_KEY);

    private void CheckVerticalInput()
        => _verticalInput = Input.GetAxisRaw(VERTICAL_AXIS_NAME);

    private void CheckHorizontalInput()
        => _horizontalInput = Input.GetAxisRaw(HORIZONTAL_AXIS_NAME);
}
