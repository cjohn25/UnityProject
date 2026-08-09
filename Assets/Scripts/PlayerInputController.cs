using UnityEngine;
[RequireComponent(typeof(PlayerPhysicsController))]
public class PlayerInputController : MonoBehaviour
{
    // Captures keyboard/controller inputs
   
    private PlayerPhysicsController physicsController;
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public bool FireWeapons { get; private set; }

    //public event Action OnFire = delegate { };
    private void Awake()
    {
        physicsController = GetComponent<PlayerPhysicsController>();
    }

    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        FireWeapons = Input.GetKeyDown(KeyCode.F);
        if (FireWeapons)
        {
            //OnFire();
            //Debug.Log("TestFire");
        }

    }
}
