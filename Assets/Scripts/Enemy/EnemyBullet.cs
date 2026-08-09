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


    private bool PlayerIsDead;
    private GameObject PlayerChar;
    public GameObject gameOverUIMenu;
    void Awake()
    {
        Destroy(gameObject, life);

    }

    void Update()
    {
         
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
    
    void OnCollisionEnter2D(Collision2D PlayerCollision)
    {
         
        if (PlayerCollision.gameObject.CompareTag("Player"))
        { 
            PlayerChar = GameObject.FindGameObjectWithTag("Player");
            PlayerCollision.gameObject.GetComponent<Player>().PlayerMaxHeatlh -= 40;
            if (PlayerCollision.gameObject.GetComponent<Player>().PlayerMaxHeatlh <= 0 && !PlayerIsDead)
            {
                Player playerScript = gameObject.GetComponent<Player>();
                GameObject playerObj = GameObject.FindWithTag("Player");
                Player playerScript1 = playerObj.GetComponent<Player>();

                playerScript1.PlayerParticleControlPlayable1();
                //playerScript1.gameOverMenu();
                PlayerIsDead = true;
                //Destroy(PlayerCollision.gameObject);
            }


        }
    }

}
