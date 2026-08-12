using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Settings")]
    [SerializeField] private Transform weaponMountPoint;
    private float FireSpeed = 10f;
    [SerializeField] private GameObject bulletPrefab;
    //private Rigidbody projectile;  
    [SerializeField]
    private float fireRefreshRate = 1f;
    private float nextFireTime;

    private Vector2 moveDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

   
    private void Update()
    { 
        if (CanFire())
        {
            if (Input.GetKeyDown(KeyCode.F)) { 
            FireWeapon();
            }
        }
    }
 
    private bool CanFire()
    {
        return Time.time >= nextFireTime;
    }

    private void FireWeapon()
    {
        nextFireTime = Time.time + fireRefreshRate;
        var bullet = Instantiate(bulletPrefab, weaponMountPoint.position, weaponMountPoint.rotation);
         
            Debug.Log(weaponMountPoint.position.x);

        if (transform.localScale.x > 0)
        {
            //Debug.Log("Right");
            bullet.GetComponent<Rigidbody2D>().linearVelocity = weaponMountPoint.right * FireSpeed;
        }
        else
        {
            //Debug.Log("left");
            bullet.GetComponent<Rigidbody2D>().linearVelocity = -weaponMountPoint.right * FireSpeed;
        }

        



    }

   
}
