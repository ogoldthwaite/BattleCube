using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement
{

    public void MoveForward(Rigidbody rb, float speed)
    {
        rb.AddForce(Vector3.forward * speed);
    }

    public void MoveBackward(Rigidbody rb, float speed)
    {
        rb.AddForce(Vector3.back * speed);
    }

    public void MoveRight(Rigidbody rb, float speed)
    {
        rb.AddForce(Vector3.right * speed);
    }

    public void MoveLeft(Rigidbody rb, float speed)
    {
        rb.AddForce(Vector3.left * speed);
    }

    public void Jump(Rigidbody rb, float jumpForce)
    {
        rb.AddForce(Vector3.up * jumpForce);
    }



}
