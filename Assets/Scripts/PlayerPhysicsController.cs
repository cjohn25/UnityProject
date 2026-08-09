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
    [Header("Dash Settings")]
    public float dashSpeed;
    public float dashLength = .5f, dashCooldown = 1f;
    private float dashCounter;
    private float dashCoolCounter;
    private float activeMoveSpeed;

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
        activeMoveSpeed = movespeed;
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
