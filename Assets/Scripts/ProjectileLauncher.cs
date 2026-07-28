using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private Rigidbody projectile;
    [SerializeField]
    private Transform weaponMountPoint;
    [SerializeField]
    private float fireForce = 30f;

    private void Awake()
    {

        //GetComponent<Player>().Fire += HandleFire;

    }

    private void HandleFire()
    {
        var bullet = Instantiate(projectile, weaponMountPoint.position, weaponMountPoint.rotation);
        bullet.AddForce(bullet.transform.right * fireForce);

    }
}
