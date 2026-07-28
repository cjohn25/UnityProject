using UnityEngine;

public class Player : MonoBehaviour
{
   
 
    [Header("Character Settings")]
    [SerializeField] public int PlayerMaxHeatlh = 120;
    private string PlayerName = "CJ";

    [SerializeField] public GameManagerScript menuPlayer;
    //[SerializeField] public GameObject gameOverUI;
    [SerializeField] public UnityEngine.UI.Image PlayerhealthBar;
    //[Header("Movement Settings")]
    //private float movespeed = 8f;
    //private float jumpForce = 25.0f;

    private bool PlayerIsDead;
    [Header("Ground Check Settings")]
    private bool isGrounded;
    private float horizontalInput;

  

    [Header("Others Settings")]
    //private float horizontal;
    //private bool isFacingRight = true;
    private float playerHealth;
    private Rigidbody2D rb;
    private Gun2D GunController;
    private GameObject deathParticlesSystemPrefab;
    private void Awake()
    {
       
    }
    void Start()
    { 
        ChangeName();
        playerHealth = PlayerMaxHeatlh;
    }

    void Update()
    {

        PlayerhealthBar.fillAmount = Mathf.Clamp(PlayerMaxHeatlh / playerHealth, 0, 1);
    }
  public void gameOverMenu()
    {
        menuPlayer.gameOver();
        
    }

    private void ChangeName()
    {
        PlayerName = "CJJJ";

        Debug.Log(PlayerName + " - started the Game!");

    }
    private void TakeDamage(int damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0)
        {
            Die();
        }
    }
    
    //private void Jump() { 
    //  if(Input.GetButtonDown("Jump") )
    //    {
    //        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    //    }
    //}
    //public void Movement()
    //{
    //    horizontal = Input.GetAxis("Horizontal");
    //    rb.linearVelocity = new Vector2(horizontal * movespeed, rb.linearVelocityY);
    //}
    //public void Flip()
    //{
    //    if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
    //    {
    //        isFacingRight = !isFacingRight;
    //        Vector3 localScale = transform.localScale;
    //        localScale.x *= -1f;
    //        transform.localScale = localScale;
    //    }
    //}


    public void Die()
    {
        Instantiate(deathParticlesSystemPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
