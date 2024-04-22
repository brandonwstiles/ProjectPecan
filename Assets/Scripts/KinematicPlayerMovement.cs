using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KinematicPlayerMovement : MonoBehaviour
{

    //q: how do i write serialized fields?

    Rigidbody2D rb;

    public float speed = 5f;
    public float jumpVelocity = 10f;
    public float jumpTime = 4f;

    private float gravity;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isJumping;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        gravity = -2 * jumpVelocity / Mathf.Pow(jumpTime, 2);
    }

    void Update()
    {
        GroundCheck();

        Move(Input.GetAxis("Horizontal"));

        FallingCheck();

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;

    }
    void ApplyGravity()
    {
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + gravity * Time.deltaTime);
    }
    
    void RemoveGravity() 
    {        
        rb.velocity = new Vector2(rb.velocity.x, 0);
    }

    void Move(float direction)
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }

    void Jump()
    {
        //rb.velocity = new Vector2(rb.velocity.x, 0);
        if (isGrounded)
        {
            isGrounded = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            isJumping = true;
        }
    }

    void GroundCheck()
    {
        if (isGrounded)
        {
            RemoveGravity();
        }
        else
        {
            ApplyGravity();
        }
    }

    void FallingCheck()
    {
        if (rb.velocity.y < 0)
        {
            isJumping = false;
        }
    }

    void Slide()
    {

    }

    void Dash()
    {

    }

    void DoubleJump()
    {

    }

    void WallJump()
    {

    }

    void WallSlide()
    {

    }
}
