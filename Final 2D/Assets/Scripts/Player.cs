using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _kickLeft;
    [SerializeField] private GameObject _kickRight;
    [SerializeField] private GameController _gameController;
    // Add member variables to store references to this GameObject's 
    //      Rigidbody, Animator, and SpriteRenderer.
    private Rigidbody2D _rb2D;
    private Animator _animator;
    private SpriteRenderer _renderer;
    [SerializeField] private float _speed;
    [SerializeField] private float _jump;

    private bool _facingLeft;
    private bool _isGrounded;

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    // ------------------------------------------------------------------------
    // Add a built-in UNITY METHOD that runs EVERY FRAME.
        // Detect input to move player left/right, jump, and kick
        // Change character facing with SpriteRenderer.flipX value
        // Set animation parameters
    private void Update()
    {
        Debug.Log("UPDATE IS RUNNING!");
        float horizontal = Input.GetAxisRaw("Horizontal");

        _rb2D.linearVelocity = new Vector2(horizontal * _speed, _rb2D.linearVelocity.y);


        if (horizontal < 0)
        {
            _facingLeft = true;
        }
        else if (horizontal > 0)
        {
            _facingLeft = false;
        }

        _renderer.flipX = _facingLeft;


        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && _isGrounded)
        {    
            _rb2D.linearVelocity = new Vector2(_rb2D.linearVelocity.x, _jump);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("KICK METHOD START");
            Kick();
        }

        _animator.SetFloat("Speed", Mathf.Abs(horizontal));
        _animator.SetBool("Grounded", _isGrounded);
    }

    // ------------------------------------------------------------------------
    private void Kick()
    {
        // Set animation parameter.
        _animator.SetTrigger("Kick");
        Debug.Log("KICK METHOD STARTED!");

        if (_kickLeft == null || _kickRight == null)
        {
            Debug.LogError("KICK REFERENCES ARE MISSING!");
            return;
        }

        GameObject hitbox = _facingLeft ? _kickLeft : _kickRight;

        _kickLeft.SetActive(false);
        _kickRight.SetActive(false);

        Debug.Log("ACTIVATING HITBOX: " + hitbox.name);

        hitbox.SetActive(true);
    }

    // ------------------------------------------------------------------------
    // Use a built-in Unity method to detect COLLISION.
    // Use this to avoid allowing the Player to double jump- they should
    //      collide with an object with the Ground tag before being able to
    //      jump again.
    private void OnCollisionStay2D(Collision2D collision)
    {   
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
}
