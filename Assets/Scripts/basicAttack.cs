using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack
{
    private bool isHitting;
    private int numRayCasts = 5;


    public IEnumerator AttackOne(float yMin, float yMax, float strength, GameObject player, float hitDistance, float hitCooldown, bool facingRight)
    {
        float yInterval = (yMax - yMin) / numRayCasts;
        Vector3 position = player.transform.position;
        position.y = yMin;

        Vector3 direction = facingRight ? Vector3.right : Vector3.left;

        if (!isHitting)
        {
            isHitting = true;
                for (int i = 0; i < numRayCasts; i++)
                {
                    position.y = yInterval * i + yMin;
                    RaycastHit hit;
                    Debug.DrawRay(position, direction * hitDistance, Color.black);
                    if (Physics.Raycast(position, direction, out hit, hitDistance))
                    {
                        if (hit.collider != null)
                        {
                            if (hit.collider.gameObject.tag == "Player")
                            {
                                Rigidbody rb = hit.collider.gameObject.GetComponent<Rigidbody>();
                                rb.AddForce((hit.collider.gameObject.transform.position - position) * strength);
                            }
                            else if (hit.collider.gameObject.tag == "Hittable")
                            {
                                Rigidbody rb = hit.collider.gameObject.GetComponent<Rigidbody>();
                                rb.AddForce((hit.collider.gameObject.transform.position - position) * strength);
                            }
                        }
                    }
                }
        }
        yield return new WaitForSeconds(hitCooldown);
        isHitting = false;
    }

    





}
