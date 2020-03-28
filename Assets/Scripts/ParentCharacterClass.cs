using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentCharacterClass : MonoBehaviour
{
    public float playerMass = 2;
    public float moveSpeed = 50;
    public float jumpForce = 50;
    public int maxJumps = 2;
    private int jumpCount;

    private Rigidbody rb;
    private CharacterMovement moveScript;

    // Start is called before the first frame update
    void Start()
    {
        moveScript = new CharacterMovement();
        rb = GetComponent<Rigidbody>();
        rb.mass = playerMass;



    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            moveScript.Jump(rb, jumpForce);
            jumpCount--;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            moveScript.MoveLeft(rb, moveSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveScript.MoveRight(rb, moveSpeed);
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Floor")
        {
            jumpCount = maxJumps;
        }
    }

}
