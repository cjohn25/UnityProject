using System;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;

public class SpikeTraps : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private GameObject PlayerChar;
    private const string RAISE_PARAM = "RAISE";
    private EnemyBullet EB;

    private bool PlayerIsDead;
    private void OnTriggerEnter2D(Collider2D collision)
    {

      
         
        if (collision.gameObject.tag == "Player")
        {
            anim.SetTrigger(RAISE_PARAM);  
            collision.gameObject.GetComponent<Player>().PlayerMaxHeatlh -= 40;

            if (collision.gameObject.GetComponent<Player>().PlayerMaxHeatlh <= 0 && !PlayerIsDead)
            { 
                GameObject playerObj = GameObject.FindWithTag("Player");
                Player playerScript1 = playerObj.GetComponent<Player>();
                playerScript1.PlayerParticleControlPlayable1();
                PlayerIsDead = true;
            }

            }
    }

}