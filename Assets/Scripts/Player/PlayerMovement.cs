using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpForce = 5.0f;

    private Rigidbody2D rb2d;

    private float horizontalMove;
    private bool isJumping;
    private bool isOnGround;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        isJumping = false;
        isOnGround = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isJumping)
        {
            isJumping = true;
        }
    }
    
    private void FixedUpdate()
    {
        playerMove(horizontalMove);

        if (isJumping && isOnGround)
        {
            isJumping = false;
            playerJump();
        }
    }
    
    private void playerMove(float move)
    {
        rb2d.velocity = new Vector2(horizontalMove * speed, rb2d.velocity.y);
    }
    
    private void playerJump()
    {
        rb2d.AddForce(new Vector2(rb2d.velocity.x, jumpForce), ForceMode2D.Impulse);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }
}
