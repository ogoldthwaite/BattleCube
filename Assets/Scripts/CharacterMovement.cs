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
                Player.transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
                facingRight = true;
            }
        }
    }

    public void MoveLeft(GameObject Player, Rigidbody rb, float speed)
    {
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(Vector3.left * speed);
            if(facingRight)
            {
                Player.transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
                facingRight = false;
            }

        }

    }

    public void Jump(Rigidbody rb, float jumpForce)
    {
        Debug.Log("Jump");
        rb.AddForce(Vector3.up * jumpForce);
    }



}
