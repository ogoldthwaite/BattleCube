using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentCannonClass : MonoBehaviour
{
    public GameObject bullet;
    public int ammo = 50;
    public float fireRate = .5f;
    public float bulletSpeed = 1;

    private float bulletSpeedCoefficient = 1000;

    private bool isFiring;
    protected void Shoot()
    {
        if (!isFiring && ammo > 0)
        {
            ammo--;
            StartCoroutine(ShootCannon());
        }
    }

    IEnumerator ShootCannon()
    {
        isFiring = true;
        GameObject cannonBall = Instantiate(bullet, transform.position, Quaternion.identity);
        cannonBall.GetComponent<Rigidbody>().AddExplosionForce(bulletSpeed * bulletSpeedCoefficient, transform.position, 2);
        yield return new WaitForSeconds(fireRate);
        isFiring = false;
    }


}
