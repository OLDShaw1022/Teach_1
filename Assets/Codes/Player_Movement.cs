using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //value
    public float speed = 5f;
    public float jumpForce;
    Vector2 movement;
    Rigidbody2D rb;

    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;
    //logic
    bool isGrounded;

    //Do when system start
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //Update every screen frame
    void Update()
    {
        //Input

        //Left and right movement
        movement.x = Input.GetAxisRaw("Horizontal");
        //Jump when W key is down
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Jump();
        }
    }

    //Update every certain frame
    private void FixedUpdate()
    {
        //Change left and right rb velocity
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);

        //Logic

        //change isGrounded to true when OverlapCircle touch groundLayer
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    //Jump function
    void Jump()
    {
        Vector2 jumpVec = new Vector2(0, 1 * jumpForce);
        rb.AddForce(jumpVec, ForceMode2D.Impulse);
    }

    //Draw something on editor screen when selected
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
