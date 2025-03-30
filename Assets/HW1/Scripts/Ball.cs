using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private string HorizontalAxis = "Horizontal";
    private string VerticalAxis = "Vertical";

    [SerializeField] private int _movingSpeed;
    [SerializeField] private int _jumpSpeed;

    private Vector3 _movingVector = Vector3.zero;
    private Vector3 _jumpVector = Vector3.up;

    private Rigidbody _rigidbody;
    private bool _isGrounded;
    private bool _isJumping;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CalculateMovingVector();
        CalculateJump();

        Debug.Log(_isJumping);
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(_movingVector * _movingSpeed, ForceMode.Acceleration);

        if (_isJumping)
        {
            _rigidbody.AddForce(_jumpVector * _jumpSpeed, ForceMode.Impulse);
            _isJumping = false;
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
    {
        float horizontalMoving = Input.GetAxisRaw(HorizontalAxis);
        float verticalMoving = Input.GetAxisRaw(VerticalAxis);

        Vector3 horizontalVector = new Vector3(horizontalMoving, 0, 0);
        Vector3 verticalVector = new Vector3(0, 0, verticalMoving);

        _movingVector = horizontalVector + verticalVector;
    }

    private void CalculateJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            _isJumping = true;            
    }

    
}
