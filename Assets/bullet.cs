using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class bullet : MonoBehaviour
{ 
    public float life = 3;
    private GameObject EnemyChar;  
    void Awake()
    {
        Destroy(gameObject, life);
     
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        { 
            EnemyChar = GameObject.FindGameObjectWithTag("Enemy");
            collision.gameObject.GetComponent<EnemyScript>().maxHealth -= 20;
            if(collision.gameObject.GetComponent<EnemyScript>().maxHealth < 0)
            {
             
                
                GameObject EnemyObj = GameObject.FindWithTag("Enemy");
                EnemyScript Enemy1 = EnemyObj.GetComponent<EnemyScript>(); 
                Enemy1.ParticleControlPlayable(collision);
                //DEE1.SetStartDelay();
            }
         

        }
    }
     
}
