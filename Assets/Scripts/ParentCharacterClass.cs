﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentCharacterClass : MonoBehaviour
{
    public float playerMass = 2;
    public float playerHeight = 2;
    public float hitStrength = 100;
    public float hitDistance = 1.5f;
    public float hitCooldown = 1;
    public float moveSpeed = 50;
    public float jumpForce = 50;
    public int maxJumps = 2;
    private int jumpCount;
    public CharacterMovement moveScript;

    private Rigidbody rb;
    private BasicAttack punch;

    // Start is called before the first frame update
    void Start()
    {
        moveScript = new CharacterMovement();
        punch = new BasicAttack();
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

        if(Input.GetMouseButtonDown(0))
        {
            float yMin = playerHeight * 0.25f + transform.position.y - playerHeight/2.5f;
            float yMax = playerHeight * 0.75f + transform.position.y - playerHeight/2.5f;

            StartCoroutine(punch.AttackOne(yMin, yMax, hitStrength, gameObject, hitDistance, 0, moveScript.facingRight));

        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            moveScript.MoveLeft(gameObject, rb, moveSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveScript.MoveRight(gameObject, rb, moveSpeed);
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
