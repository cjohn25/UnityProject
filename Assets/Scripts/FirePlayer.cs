using UnityEngine;

public class FirePlayer : MonoBehaviour
{
    public float Speed = 4.5f;

     
    public void Update()
    {
        transform.position += -transform.right * Time.deltaTime * Speed;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
