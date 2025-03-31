using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _movingSpeed;
    [SerializeField] private int _jumpPower;

    [SerializeField] private VectorCalculations _vectorCalculations;
    [SerializeField] private Mover _mover;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private UserInput _userInput;

    private Vector3 _movingVector = Vector3.zero;
    private Vector3 _jumpVector = Vector3.up;

    private Rigidbody _rigidbody;
    private bool _isGrounded;
    private bool _doJump;

    private void Awake()
        => _rigidbody = GetComponent<Rigidbody>();

    private void Update()
    {
        CalculateMovingVector();
        CalculateJump();
    }

    private void FixedUpdate()
    {
        _mover.DoMove(_rigidbody, _movingVector, _movingSpeed);

        if (_doJump)
        {
            _jumper.DoJump(_rigidbody, _jumpVector, _jumpPower);
            _doJump = false;
        }        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Ground>() != null)
            _isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.GetComponent<Ground>() != null)
            _isGrounded = false;
    }

    private void CalculateMovingVector()
        => _movingVector = _vectorCalculations.CalculateMovingVector(_userInput.HorizontalInput, _userInput.VerticalInput);

    private void CalculateJump()
    {
        if (_userInput.JumpKeyPressed && _isGrounded)
            _doJump = true;
    }    
}
