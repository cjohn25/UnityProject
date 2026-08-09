using UnityEngine;
using UnityEngine.UIElements;

public class EnemyWeapon : MonoBehaviour
{
    //[Header("Weapon Settings")]
    //[SerializeField] private Transform weaponMountPoint;
    ////private float FireSpeed = 15f;
    //[SerializeField] private GameObject bulletPrefab;
    //private Rigidbody projectile;
    //[SerializeField]
    //private float fireRefreshRate = 3f;
    //private float nextFireTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Update()
    {

        //if (CanFire())
        //{
        //    FireWeapon();
        //}
    }

    //private bool CanFire()
    //{
    //    //return Time.time >= nextFireTime;
    //}

    private void FireWeapon()
    {
        //nextFireTime = Time.time + fireRefreshRate;
        ////var bullet = Instantiate(bulletPrefab, weaponMountPoint.position, weaponMountPoint.rotation);
        ////Debug.Log(weaponMountPoint.position.x+ "---test"+ " -- "+ weaponMountPoint.right);

        ////bullet.GetComponent<Rigidbody2D>().linearVelocity = weaponMountPoint.right * FireSpeed;
        //// 1. Spawn the bullet at the fire point's position
        //GameObject newBullet = Instantiate(bulletPrefab, weaponMountPoint.position, Quaternion.identity);

        //// 2. Get the Bullet component from the newly spawned object
        //EnemyBullet bulletScript = newBullet.GetComponent<EnemyBullet>();

        //// 3. Find out if the player is facing right (positive X scale) or left (negative X scale)
        //// Mathf.Sign converts values to either 1f or -1f
        //float currentFacingDirection = Mathf.Sign(transform.localScale.x);
        //Debug.Log("FireWeapon"+transform.localScale.x);
        //// 4. Send that direction value to the bullet
        //bulletScript.SetupBullet(currentFacingDirection);

    }
 
}
