using System;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    private const string HORIZONTAL_AXIS_NAME = "Horizontal";
    private const string VERTICAL_AXIS_NAME = "Vertical";
    private const string MOUSE_X_AXIS_NAME = "Mouse X";
    private const KeyCode JUMP_KEY = KeyCode.Space;

    private Vector3 _lastMousePosition;

    private float _horizontalInput;
    private float _verticalInput;
    private float _mouseMovingX;
    private bool _jumpKeyPressed;

    public float HorizontalInput => _horizontalInput;
    public float VerticalInput => _verticalInput;
    public bool JumpKeyPressed => _jumpKeyPressed;
    public float MouseMovingX => _mouseMovingX;

    private void Awake()
        => _lastMousePosition = Input.mousePosition;

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
        
        //Vector3 currentPosition = Input.mousePosition;
        //float delta = currentPosition.x - _lastMousePosition.x;
        //_lastMousePosition = currentPosition;

        //_mouseMoving = 0;

        //if (delta > 0)
        //    _mouseMoving = 1;
        //else if (delta < 0)
        //    _mouseMoving = -1;
    }

    private void CheckJumpKeyPressed()
        => _jumpKeyPressed = Input.GetKeyDown(JUMP_KEY);

    private void CheckVerticalInput()
        => _verticalInput = Input.GetAxisRaw(VERTICAL_AXIS_NAME);

    private void CheckHorizontalInput()
        => _horizontalInput = Input.GetAxisRaw(HORIZONTAL_AXIS_NAME);
}
