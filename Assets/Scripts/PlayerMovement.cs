using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float gravity = 20f;

    private bool isGrounded;
    private Vector2 targetPosition;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate movement direction
        Vector2 movement = new Vector2(horizontalInput * moveSpeed * Time.deltaTime, 0f);

        // Apply gravity
        if (!isGrounded)
        {
            movement.y -= gravity * Time.deltaTime;
        }

        // Apply movement
        targetPosition += movement;
        transform.position = Vector2.Lerp(transform.position, targetPosition, Time.deltaTime * 10f);

        // Check for jump
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        // Apply jump force
        Vector2 jumpVelocity = new Vector2(0f, jumpForce);
        targetPosition += jumpVelocity;
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the character is grounded
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }
}