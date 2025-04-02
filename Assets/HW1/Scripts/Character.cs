using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Transform _orientation;

    [SerializeField] private int _movingSpeed;
    [SerializeField] private int _jumpPower;

    [SerializeField] private Mover _mover;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private UserInput _userInput;    

    private Vector3 _movingVector = Vector3.zero;
    private Vector3 _jumpVector = Vector3.up;
    
    private Rigidbody _rigidbody;    
    private bool _doJump;
    
    private int _groundCollisionCounter;
    private bool _isGrounded;
        
    private void Awake()
        => _rigidbody = GetComponent<Rigidbody>();
        
    private void Update()
    {
        _isGrounded = _groundCollisionCounter > 0;

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
            _groundCollisionCounter++;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.GetComponent<Ground>() != null)
            _groundCollisionCounter--;
    }
    
    private void CalculateMovingVector()
        => _movingVector = _orientation.forward * _userInput.VerticalInput + _orientation.right * _userInput.HorizontalInput;
        
    private void CalculateJump()
    {
        if (_userInput.JumpKeyPressed && _isGrounded)
            _doJump = true;
    }        
}
