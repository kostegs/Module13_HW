using UnityEngine;

public class UserInput : MonoBehaviour
{
    private const string HORIZONTAL_AXIS_NAME = "Horizontal";
    private const string VERTICAL_AXIS_NAME = "Vertical";
    private const KeyCode JUMP_KEY = KeyCode.Space;

    private float _horizontalInput;
    private float _verticalInput;
    private bool _jumpKeyPressed;

    public float HorizontalInput => _horizontalInput;
    public float VerticalInput => _verticalInput;
    public bool JumpKeyPressed => _jumpKeyPressed;
    
    void Update()
    {
        CheckHorizontalInput();
        CheckVerticalInput();
        CheckJumpKeyPressed();
    }

    private void CheckJumpKeyPressed()
        => _jumpKeyPressed = Input.GetKeyDown(JUMP_KEY);

    private void CheckVerticalInput()
        => _verticalInput = Input.GetAxisRaw(VERTICAL_AXIS_NAME);

    private void CheckHorizontalInput()
        => _horizontalInput = Input.GetAxisRaw(HORIZONTAL_AXIS_NAME);
}
