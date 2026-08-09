using UnityEditor.Tilemaps;
using UnityEngine;
using System; 
using System.Collections; 
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using UnityEngine.InputSystem;
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
    public float dashDistance = 15f;
    bool isDashing;
    float doubleTapTime;
    KeyCode lastKeyCode;
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
        horizontal = Input.GetAxis("Horizontal");
        //Movement();
        Flip();
        if (isDashing) return;
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (doubleTapTime > Time.time && lastKeyCode == KeyCode.A)

            {
                Debug.Log("dash--");
                StartCoroutine(Dash(-1));
            }
            else
            {
                doubleTapTime = Time.time + 0.5f;
            }
            lastKeyCode = KeyCode.A;
           
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (doubleTapTime > Time.time && lastKeyCode == KeyCode.D)

            {
                Debug.Log("dash--");
                StartCoroutine(Dash(1));
            }
            else
            {
                doubleTapTime = Time.time + 0.5f;
            }
            lastKeyCode = KeyCode.D;
           
        }
        if (!isDashing)
        {
            Movement();
        }


        if (CanJump() && Input.GetButtonDown("Jump"))
        {

            nextJumpTime = Time.time + JumpRefreshRate;
            Jump();
        }
       

    }
 IEnumerator Dash(float Direction)
    {
        isDashing = true;
        rb.linearVelocity = new Vector2(rb.linearVelocityX, 0f);
        rb.AddForce(new Vector2(dashDistance * Direction, 0f), ForceMode2D.Impulse);
        float gravity = rb.gravityScale;
        rb.gravityScale = 0;

        yield return new WaitForSeconds(0.4f);
        isDashing = false;
        rb.gravityScale = gravity;

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
      

        rb.linearVelocity = new Vector2(horizontal * movespeed , rb.linearVelocityY);
     
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
