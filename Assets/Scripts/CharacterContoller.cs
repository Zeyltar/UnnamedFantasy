using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterContoller : MonoBehaviour
{

    protected Vector2 direction;
    protected SpriteRenderer spriteRenderer;
    protected Animator animator;
    protected Rigidbody2D rb;

    private int colliderCount;
    private bool jumped;
    private bool isJumping;

    [SerializeField]
    protected float MoveSpeed;
    [SerializeField]
    protected float JumpForce;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        colliderCount = 0;
        jumped = false;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * MoveSpeed * Time.deltaTime);
        animator.SetInteger("MoveX", (int)direction.x);

        if (direction.x < 0 )
            spriteRenderer.flipX = true;
        else if (direction.x > 0)
            spriteRenderer.flipX = false;
         
       

    }

    private void FixedUpdate()
    {
        if (jumped)
        {
            rb.velocity = Vector2.up * JumpForce;
        }
        else if (isJumping && colliderCount <= 0)
        {
            rb.velocity = Vector2.down * JumpForce * 1.15f;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>() * Vector2.right;
    }

    public void Jump(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            if (colliderCount > 0)
            {
                jumped = true;
            }
        }
        if (context.duration > InputSystem.settings.defaultHoldTime || context.canceled)
        {
            jumped = false;
            isJumping = true;

        }

    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetTrigger("Attack");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        colliderCount++;
        isJumping = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        colliderCount--;
    }
}
