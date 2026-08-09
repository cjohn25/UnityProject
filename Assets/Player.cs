using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class Player : MonoBehaviour
{

    [SerializeField] ParticleSystem collectPart1 = null;
    [Header("Character Settings")]
    [SerializeField] public int PlayerMaxHeatlh = 120;
    private string PlayerName = "CJ";

    [SerializeField] public GameManagerScript menuPlayer; 
    [SerializeField] public UnityEngine.UI.Image PlayerhealthBar;
    //[Header("Movement Settings")] 

    private bool PlayerIsDead;
    [Header("Ground Check Settings")]
    private bool isGrounded;
    private float horizontalInput;
     

    [Header("Others Settings")] 
    private float playerHealth;
    private Rigidbody2D rb; 
    
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

    public void PlayerParticleControlPlayable1()
    {
        //var em1 = collectPart1.emission;
        //em1.enabled = true;

        DelayHelper.DelayAction(this, Die, 0.3f);

    }

    public void Die()
    {
        ParticleSystem explosion1 = Instantiate(collectPart1, transform.position, Quaternion.identity);
        explosion1.Play();
        Destroy(gameObject);

        gameOverMenu();
    }

   
}
