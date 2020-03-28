using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentGunClass : MonoBehaviour
{
    public int ammo;
    public float fireRate;
    public float bulletSpeed;
    public GameObject bullet;


    private bool shooting = false;

    void Start()
    {
        
    }

    void Update()
    {

    }

    protected void Shoot()
    {
        if(!shooting && ammo > 0)
        {
            ammo--;
            StartCoroutine(ShootGun());
        }

    }
    
    IEnumerator ShootGun()
    {
        shooting = true;
        GameObject currentBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        Rigidbody bulletRB = currentBullet.GetComponent<Rigidbody>();
        bulletRB.AddForce(new Vector3(bulletSpeed, 0, 0));
        yield return new WaitForSeconds(fireRate);
        shooting = false;
    }
}
