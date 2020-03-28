using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDuperBullet : ParentBulletClass
{
    public float dupeCD = 1.0f;
    public float initialCD;
    public GameObject dupedBullet;
    public float dupeBulletForce;

    private bool duping = true;

    void Start()
    {
        DestroyBullet();
       // dupeBulletForce = gameObject.GetComponent<Rigidbody>().velocity.magnitude;
        StartCoroutine(InitialDelay());
    }

    void Update()
    {
        if(!duping)
        {
            StartCoroutine(DupeBullet());
        }
    }

    IEnumerator DupeBullet()
    {
        duping = true;
        float offset = 0.5f;

        float randVal = Random.Range(0.1f, 1.0f);

        dupeBulletForce = randVal > 0.5f ? dupeBulletForce*randVal : -dupeBulletForce*randVal;

        // Creating bullet and adding force to it
        Vector3 spawnPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - offset, 0);
        GameObject currentBullet = Instantiate(dupedBullet, spawnPos, Quaternion.identity);
        currentBullet.GetComponent<ParentBulletClass>().destroyTime = 2;
        Rigidbody bulletRB = currentBullet.GetComponent<Rigidbody>();
        bulletRB.AddForce(new Vector3(dupeBulletForce, dupeBulletForce/2, 0));

        //spawnPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + offset, 0);
        //currentBullet = Instantiate(dupedBullet, gameObject.transform.position, Quaternion.identity);
        //currentBullet.GetComponent<ParentBulletClass>().destroyTime = 2;
        //bulletRB = currentBullet.GetComponent<Rigidbody>();
        //bulletRB.AddForce(new Vector3(dupeBulletForce, dupeBulletForce/2, 0));


        yield return new WaitForSeconds(dupeCD);

        duping = false;
    }

    IEnumerator InitialDelay()
    {
        yield return new WaitForSeconds(initialCD);

        duping = false;
    }
}
