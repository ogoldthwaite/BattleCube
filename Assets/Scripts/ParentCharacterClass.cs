using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentCharacterClass : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody rb;
    private CharacterMovement moveScript;

    // Start is called before the first frame update
    void Start()
    {
        moveScript = new CharacterMovement();
        rb = GetComponent<Rigidbody>();



    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            moveScript.Jump(rb, jumpForce);
        }

        if (Input.GetKey(KeyCode.W))
        {
            moveScript.MoveForward(rb, moveSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveScript.MoveBackward(rb, moveSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveScript.MoveLeft(rb, moveSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveScript.MoveRight(rb, moveSpeed);
        }

    }

}
