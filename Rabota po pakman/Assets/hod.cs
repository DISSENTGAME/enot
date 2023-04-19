using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hod : MonoBehaviour
{
    public int Speed;

    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector3(Speed * Time.deltaTime, rb.velocity.y, rb.velocity.z);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector3(-Speed * Time.deltaTime, rb.velocity.y, rb.velocity.z);
        }

    }
}