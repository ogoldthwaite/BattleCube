using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveForward(Rigidbody rb, float speed)
    {
        rb.AddForce(Vector3.forward * speed);
    }

    public void moveBackward(Rigidbody rb, float speed)
    {
        rb.AddForce(Vector3.back * speed);
    }

    public void moveRight(Rigidbody rb, float speed)
    {
        rb.AddForce(Vector3.right * speed);
    }

    public void moveLeft(Rigidbody rb, float speed)
    {
        rb.AddForce(Vector3.left * speed);
    }

    public void jump(Rigidbody rb, float jumpForce)
    {
        rb.AddForce(Vector3.up * jumpForce);
    }



}
