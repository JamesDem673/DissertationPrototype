using System;
using System.Linq.Expressions;
using System.Xml.Serialization;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{

    [SerializeField] private Animator _animator; 
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jump = 100f;

    private float _currentVelocity;
    private Rigidbody2D _rigidbody;

    private bool _isJumping;
    private bool _facingFront = true;

    public bool _isAttacking = false;
    public bool _nextAttack = false;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigidbody.velocity = new Vector2(_currentVelocity, _rigidbody.velocity.y);

        if(_rigidbody.velocity.x > 0)
        {
            _animator.SetBool("IsRunning", true);

            if(!_facingFront)
            {
                transform.Rotate(0, 180, 0);
                _facingFront = true; 
            }
        }
        else if (_rigidbody.velocity.x < 0)
        {
            _animator.SetBool("IsRunning", true);

            if (_facingFront)
            {
                transform.Rotate(0, 180, 0);
                _facingFront = false;
            }
        }
        else if (_rigidbody.velocity.x ==  0) 
        {
            _animator.SetBool("IsRunning", false);
        }

    }

    public void OnAttack(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (!_isAttacking && !_isJumping)
            {
                _isAttacking = true;
                _animator.SetBool("IsAttacking", true);
            }
            else if (_isAttacking && !_isJumping)
            {
                _nextAttack = true;
                _animator.SetBool("NextAttack", true);
            }
        }
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        _currentVelocity = ctx.ReadValue<float>() * speed;
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (!_isJumping)
        {
            _rigidbody.AddForce(new Vector2(_rigidbody.velocity.x, jump));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            _isJumping = false;
            _animator.SetBool("IsJumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isJumping = true;
            _animator.SetBool("IsJumping", true);
        }
    }

}