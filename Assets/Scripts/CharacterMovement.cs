using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement
{
    public float maxSpeed = 20;
    public bool facingRight = true;
    

/*    public void MoveForward(Rigidbody rb, float speed)
    {
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(Vector3.forward * speed);
        }
    }

    public void MoveBackward(Rigidbody rb, float speed)
    {
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(Vector3.back * speed);
        }
    }

    */
    public void MoveRight(GameObject Player, Rigidbody rb, float speed)
    {
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(Vector3.right * speed);
            if (!facingRight)
            {

            }
        }
    }

    public void MoveLeft(Rigidbody rb, float speed)
    {
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(Vector3.left * speed);
        }
    }

    public void Jump(Rigidbody rb, float jumpForce)
    {
        rb.AddForce(Vector3.up * jumpForce);
    }



}
