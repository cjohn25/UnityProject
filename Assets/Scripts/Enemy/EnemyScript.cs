using UnityEngine; 
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UIElements;
using System.Linq;
using UnityEngine.TextCore.Text;
public class EnemyScript : MonoBehaviour
{

    [SerializeField] ParticleSystem collectPart = null;
    [SerializeField] public GameManagerScript VictoryMenu;
    [Header("Patrol Points")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField]
    private SpriteRenderer SR;
    [SerializeField] private GameObject PointA;
    [SerializeField] private GameObject PointB;
    private int startDirection = 1;
    private int currentDiriection;
    private float halfWidth;
    private Vector2 movement;
    [SerializeField] public UnityEngine.UI.Image healthBar;
    [Header("Movement Settings")]
    [SerializeField] private float speed = 1f;


    [SerializeField] private Transform weaponMountPoint1;
    //private float FireSpeed = 15f;
    [SerializeField] private GameObject bulletPrefab1;
    private Rigidbody projectile;
    private GameObject player1;
    [SerializeField]
    private float fireRefreshRate = 3f;
    private float nextFireTime;
    //private bool isFacingRight = true;
    private float horizontal;
    private Transform currentPoint;

    private bool isFacingLeft = true;

    private Transform currentTarget; 
    [SerializeField] public int maxHealth = 100;
    private float currentHealth;
    void Start()    
    {
        currentHealth = maxHealth;
        halfWidth = SR.bounds.extents.x;
        currentDiriection = startDirection;
        currentPoint = PointA.transform;
        player1 = GameObject.FindGameObjectWithTag("Player"); 
    }

    void Update()
    { 
        float xPos = transform.position.x ;
        float yPos = transform.position.y;
        healthBar.fillAmount = Mathf.Clamp(maxHealth / currentHealth, 0, 1); 
        if (rb.position.x > xPos) 
        {
            rb.linearVelocity = new Vector2(speed, 0);
            Flip();
        }
        else
        {
            rb.linearVelocity = new Vector2(-speed, 0);
            Flip();
        }
        if (CanFire1())
        {
            FireWeapon1();
        }
         
    } 
    public void VictoryOverMenu()
    {
        VictoryMenu.Victory();

    }
    private bool CanFire1()
    {
        return Time.time >= nextFireTime;
    }
    private void Flip()
    {
        //Debug.Log(horizontal+" -  "+ isFacingLeft);
        if (isFacingLeft && rb.linearVelocityX > 0f)
        {
            //Debug.Log("inside");
            isFacingLeft = !isFacingLeft;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
        if (!isFacingLeft && rb.linearVelocityX < 0f)
        {
            //Debug.Log("inside2");
            isFacingLeft = true;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    } 

    private void FireWeapon1()
    {
        nextFireTime = Time.time + fireRefreshRate;
       
        GameObject newBullet = Instantiate(bulletPrefab1, weaponMountPoint1.position, Quaternion.identity);
         
        EnemyBullet bulletScript = newBullet.GetComponent<EnemyBullet>();

        if (transform.localScale.x > 0)
        {
            bulletScript.SetDirection(Vector2.left);
        }
        else
        {
            bulletScript.SetDirection(Vector2.right);  // Move Left (-1, 0)
        }
       

    }
    public void ParticleControlPlayable(Collision2D collision)
    {
        var em = collectPart.emission;
        em.enabled = true;

        DelayHelper.DelayAction(this, Explode, 0.3f);
     
    }

    public void Explode()
    {
        
        ParticleSystem explosion = Instantiate(collectPart, transform.position, Quaternion.identity);
        explosion.Play();

        Destroy(gameObject);

        VictoryOverMenu();

    }
}
