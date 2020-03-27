using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicAttack
{
    private bool isHitting;
    private int numRayCasts;


    public IEnumerator BasicAttack(float yMin, float yMax, float strength, GameObject player, float hitDistance, float hitCooldown)
    {
        float yInterval = (yMax - yMin) / numRayCasts;
        Vector3 position = player.transform.position;
        position.y = yMin;
        if (!isHitting)
        {
            isHitting = true;
            for (int i = 0; i <= numRayCasts; i++)
            {
                position.y = yInterval * i;
                RaycastHit hit;
                if (Physics.Raycast(position, Vector3.forward, out hit, hitDistance))
                {
                    if (hit.collider != null) {
                        if (hit.collider.gameObject.tag == "Player")
                        {
                            Rigidbody rb = hit.collider.gameObject.GetComponent<Rigidbody>();
                            rb.AddForce((position - hit.collider.gameObject.transform.position) * strength);
                        }
                        else if (hit.collider.gameObject.tag == "Hittable")
                        {
                            Rigidbody rb = hit.collider.gameObject.GetComponent<Rigidbody>();
                            rb.AddForce((position - hit.collider.gameObject.transform.position) * strength);
                        }
                    }
                }
            }  
        }
        yield return new WaitForSeconds(hitCooldown);
        isHitting = false;
    }

    





}
