using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentBulletClass : MonoBehaviour
{
    public bool isExplosive = false;
    public float destroyTime = 5.0f;

    protected void DestroyBullet()
    {
        StartCoroutine(DestroyBul());
    }

    IEnumerator DestroyBul()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }

}
