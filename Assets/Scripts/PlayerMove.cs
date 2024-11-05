using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerMove : MonoBehaviour
{
    
    private Rigidbody rb;
    private float moveSpeed =10;
    public float jumpSpeed;
    public bool onGround = false;
    public bool facingRight;
    Quaternion rotation;
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
            rotation = Quaternion.Euler(0, 0, 0);
        }
        
        if (horizontal < 0)
        {
            facingRight = false;
            rotation = Quaternion.Euler(0, 180, 0);
        }
       
        Vector3 movement = new Vector3(horizontal * moveSpeed, rb.velocity.y);
        rb.velocity = movement;

        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }

        transform.rotation = rotation;

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
