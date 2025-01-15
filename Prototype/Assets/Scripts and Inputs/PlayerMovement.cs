using System;
using System.Linq.Expressions;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{

    [SerializeField] private float speed = 8f;
    [SerializeField] private float jump = 100f;

    private float _currentVelocity;
    private Rigidbody2D _rigidbody;

    private bool _isJumping;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigidbody.velocity = new Vector2(_currentVelocity, _rigidbody.velocity.y);
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
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isJumping = true;
        }
    }
}