using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float life = 3;
    private GameObject EnemyChar;
    void Awake()
    {
        Destroy(gameObject, life);
     
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(collision.gameObject);
        //Destroy(gameObject);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //collision.gameObject.GetComponent<EnemyScript>().maxHealth -= life;
            EnemyChar = GameObject.FindGameObjectWithTag("Enemy");
            collision.gameObject.GetComponent<EnemyScript>().maxHealth -= 20;
            if(collision.gameObject.GetComponent<EnemyScript>().maxHealth < 0)
            {
                Destroy(collision.gameObject);
            }
         

        }
    }
}
