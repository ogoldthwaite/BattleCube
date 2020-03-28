using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentGunClass : MonoBehaviour
{
    public int ammo;
    public float fireRate;
    public float bulletSpeed;
    public float recoil;
    public GameObject bullet;
    public GameObject player;


    private bool shooting = false;
    private CharacterMovement moveScript;

    public virtual void Start()
    {
        moveScript = player.GetComponent<ParentCharacterClass>().moveScript;
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

        print(moveScript.facingRight);
        float bulletForce = moveScript.facingRight ? bulletSpeed : -bulletSpeed;
        float recoilForce = moveScript.facingRight ? recoil : -recoil;

        float offset = moveScript.facingRight ? 1 : -1;

        Vector3 spawnPos = new Vector3(transform.position.x + offset, transform.position.y, 0);

        // Creating bullet and adding force to it
        GameObject currentBullet = Instantiate(bullet, spawnPos, Quaternion.identity);
        Rigidbody bulletRB = currentBullet.GetComponent<Rigidbody>();
        bulletRB.AddForce(new Vector3(bulletForce, 0, 0));

        // Adding kick-back force to player
        Rigidbody playerRB = player.GetComponent<Rigidbody>();
        playerRB.AddForce(new Vector3(-recoilForce, 0, 0));

        yield return new WaitForSeconds(fireRate);
        shooting = false;
    }
}
