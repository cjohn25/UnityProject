using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;   
public class EnemyBullet : MonoBehaviour
{
    public float life = 2;
    //private float flyDirection = 1f;
    private float FireSpeed = 15f;
    private Vector2 moveDirection;

    private Player playerOne;
    private bool PlayerIsDead;
    private GameObject PlayerChar;
    public GameObject gameOverUIMenu;
    void Awake()
    {
        Destroy(gameObject, life);

    }

    void Update()
    {
        // Move the bullet in the assigned direction using transform.position
        transform.position += (Vector3)moveDirection * FireSpeed * Time.deltaTime;
    }

    // This public function gets called by the Character script right when spawning
    public void SetDirection(Vector2 direction)
    {
        moveDirection = direction;

        // Optional: Flip the bullet visual if firing left
        if (direction == Vector2.left)
        {
            Vector3 scale = transform.localScale;
            scale.x = -Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
    }
    // Update is called once per frame
    //void Update()
    //{

    //    transform.Translate(Vector2.right * flyDirection * FireSpeed * Time.deltaTime);
    //}

    //public void SetupBullet(float playerDirection)
    //{
    //    flyDirection = playerDirection; 
    //    // Flip the bullet's sprite to face the correct direction
    //    Vector3 localScale = transform.localScale;
    //    localScale.x = Mathf.Abs(localScale.x) * playerDirection;
    //    transform.localScale = localScale;
    //}
    void OnCollisionEnter2D(Collision2D PlayerCollision)
    {
        //Destroy(collision.gameObject);
        //Destroy(gameObject);
        if (PlayerCollision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.GetComponent<EnemyScript>().maxHealth -= life;
            PlayerChar = GameObject.FindGameObjectWithTag("Player");
            PlayerCollision.gameObject.GetComponent<Player>().PlayerMaxHeatlh -= 40;
            if (PlayerCollision.gameObject.GetComponent<Player>().PlayerMaxHeatlh <= 0 && !PlayerIsDead)
            {
                Player playerScript = gameObject.GetComponent<Player>();
                GameObject playerObj = GameObject.FindWithTag("Player");
                Player playerScript1 = playerObj.GetComponent<Player>();
                playerScript1.gameOverMenu();
                PlayerIsDead = true;
                //gameOverUIMenu.SetActive(true);
                Destroy(PlayerCollision.gameObject);
            }


        }
    }

}
