using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerMove : MonoBehaviour
{
    
    private Rigidbody rb;
    private float moveSpeed =15;
    public float jumpSpeed;
    public bool onGround = false;
    public bool facingRight;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0)
        {
            facingRight = true;
        }
        
        if (horizontal < 0)
        {
            facingRight = false;
        }
        if (onGround)
        {
            moveSpeed = 15;
        }
        else
        {
            moveSpeed = 10;
        }
        Vector3 movement = new Vector3(horizontal * moveSpeed, rb.velocity.y);
        rb.velocity = movement;

        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        onGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        onGround = false;
    }
}
