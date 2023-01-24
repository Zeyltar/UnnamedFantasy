using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class CharacterContoller : MonoBehaviour
{

    private Vector2 direction;
    protected SpriteRenderer spriteRenderer;
    protected Animator animator;
    protected Rigidbody2D rb;

    private int _colliderCount;
    private bool _jump;
    private bool _stopJump;
    private bool _isInSuperMove;
    private Vector2 _looking;

    [SerializeField] float MoveSpeed;
    [SerializeField] float GravityModifier;
    [SerializeField] float JumpModifier = 1.5f;
    [SerializeField] float JumpDeceleration = 0.5f;
    [SerializeField] float TakeOffForce;
    
    public Vector2 Looking { get => _looking;}

    public delegate void SuperMoveDelegate(bool value);

    public SuperMoveDelegate SuperMove;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        _colliderCount = 0;
        _jump = false;
        _stopJump = false;
        _isInSuperMove = false;
        SuperMove = UpdateSuperMove;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isInSuperMove)
            transform.Translate(direction * (MoveSpeed * Time.deltaTime));
        animator.SetInteger("MoveX", (int)direction.x);

        spriteRenderer.flipX = direction.x switch
        {
            < 0 => true,
            > 0 => false,
            _ => spriteRenderer.flipX
        };
    }

    private void FixedUpdate()
    {
        if (_jump)
        {
            if (_colliderCount > 0)
                rb.velocity = Vector2.up * (TakeOffForce * JumpModifier);
        }
        else if (_stopJump)
        {
            _stopJump = false;
            if (rb.velocity.y > 0)
                rb.velocity *= JumpDeceleration;
        }
        
        if (!(_colliderCount > 0) && rb.velocity.y < 0)
        {
            rb.velocity += Physics2D.gravity * (GravityModifier * Time.deltaTime);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
            direction = context.ReadValue<Vector2>() * Vector2.right;
            
            if (direction != Vector2.zero && !_isInSuperMove)
                _looking = direction;
    }

    public void Jump(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            if (_colliderCount > 0)
            {   
                _jump = true;
            }
        }
        
        if (context.duration > InputSystem.settings.defaultHoldTime || context.canceled || context.performed)
        {
            _jump = false;
            _stopJump = true;
        }

    }

    private void UpdateSuperMove(bool value)
    {
        _isInSuperMove = value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _colliderCount++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _colliderCount--;
    }
}
