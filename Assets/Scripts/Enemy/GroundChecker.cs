using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private EnemyScript ES;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ES = GetComponent<EnemyScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!ES.CompareTag("A_Player"))
        {
            //ES.Flip();
        }
    }
}
