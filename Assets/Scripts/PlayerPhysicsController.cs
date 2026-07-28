using UnityEditor.Tilemaps;
using UnityEngine;
using System;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
[RequireComponent(typeof(PlayerInputController))]
public class PlayerPhysicsController : MonoBehaviour
{
    //Handles the physics, movement, and jumping 
 
    [Header("Movement Settings")]  
    private float movespeed = 8f;
    private float jumpForce = 25.0f;
    private PlayerInputController PlayerController;
    //private float lastThrust = float.MinValue;
    public event Action<float> ThrustChanged = delegate { };

    [Header("Others Settings")]
    [SerializeField] private Rigidbody2D rb;

    private float horizontal;
    private bool isFacingRight = true;
    private bool jumpRequested;
    private float JumpRefreshRate = 2f;
    private float nextJumpTime;
    private void Awake()
    {
        PlayerController = GetComponent<PlayerInputController>();
    }
    

    private void Update()
    {
        Movement();
        Flip();

        if (CanJump() && Input.GetButtonDown("Jump"))
        {

            nextJumpTime = Time.time + JumpRefreshRate;
            Jump();
        }
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        // 1. Check ground state before applying physics
        //if (groundCheck != null)
        //{
        //    isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        //}


        // 3. Control vertical physics forces
        //if (jumpRequested)
        //{
        //    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        //    Debug.Log("Jump force applied: " + jumpForce);
        //}

        //jumpRequested = false; // Reset the physics trigger flag

    }
    public void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    public void Movement()
    {
        horizontal = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(horizontal * movespeed, rb.linearVelocityY);
    }
    private bool CanJump()
    {
        return Time.time >= nextJumpTime;
    }
    private void Jump()
    {
        //if (Input.GetButtonDown("Jump"))
        //{

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        //}
    }

}
