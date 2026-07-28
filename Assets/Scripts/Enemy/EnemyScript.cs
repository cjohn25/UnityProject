using UnityEngine; 
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UIElements;
using System.Linq;
using UnityEngine.TextCore.Text;
public class EnemyScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


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
        // Start by walking towards Point B
        halfWidth = SR.bounds.extents.x;
        currentDiriection = startDirection;
        currentPoint = PointA.transform;
        player1 = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        //Vector2 point = currentPoint.position - transform.position;\
        float xPos = transform.position.x ;
        float yPos = transform.position.y;
        healthBar.fillAmount = Mathf.Clamp(maxHealth / currentHealth, 0, 1);
        //Debug.Log(rb.position.x + " -  "+ xPos + "   - "+ rb.linearVelocityX); 
        if (rb.position.x > xPos)
        //if(currentPoint == PointA.transform)
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

        //if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointB.transform)
        //{
        //    currentPoint = PointA.transform;
        //}
        //if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointA.transform)
        //{
        //    currentPoint = PointB.transform;
        //}
    }
    //private void Update()
    //{
    //    //rb.linearVelocity = Vector2.right * speed * currentDiriection;
    //    rb.linearVelocity = new Vector2(speed * currentDiriection, 0);
    //    movement.x = speed * currentDiriection;
    //    movement.y = rb.linearVelocityY;
    //    rb.linearVelocity = movement;
    //    FlipSprite();
    //}
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
    //public void EnemyTakeDamage(int amount)
    //{
    //    currentHealth -= amount;
    //}

    private void FireWeapon1()
    {
        nextFireTime = Time.time + fireRefreshRate;
        //var bullet = Instantiate(bulletPrefab, weaponMountPoint.position, weaponMountPoint.rotation);
        //Debug.Log(weaponMountPoint.position.x+ "---test"+ " -- "+ weaponMountPoint.right);

        //bullet.GetComponent<Rigidbody2D>().linearVelocity = weaponMountPoint.right * FireSpeed;
        // 1. Spawn the bullet at the fire point's position 
        GameObject newBullet = Instantiate(bulletPrefab1, weaponMountPoint1.position, Quaternion.identity);

        // 2. Get the Bullet component from the newly spawned object
        EnemyBullet bulletScript = newBullet.GetComponent<EnemyBullet>();

        if (transform.localScale.x > 0)
        {
            bulletScript.SetDirection(Vector2.left);
        }
        else
        {
            bulletScript.SetDirection(Vector2.right);  // Move Left (-1, 0)
        }
        // 3. Find out if the player is facing right (positive X scale) or left (negative X scale)
        // Mathf.Sign converts values to either 1f or -1f
        //float currentFacingDirection = Mathf.Sign(transform.localScale.x);
        //Debug.Log("FireWeapon" + transform.localScale.x);
        //// 4. Send that direction value to the bullet
        //bulletScript.SetupBullet(currentFacingDirection);


    }

    //private void DealDamageToCharacter()
    //{
    //    //Character EnemyCharacter = FindObjectsOfType<Character>().OrderBy(t => Vector3.Distance(transform.position, t.transform.position)).FirstOrDefault();

    //    int damageToDeal = 1;

    //    EnemyTakeDamage(damageToDeal);
    //}
}
