using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debuglog : MonoBehaviour
{

    private Rigidbody2D rbody2D;

    private float jumpForce = 350f;

    private int jumpCount = 0;

    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        Debug.Log("hello world");
    }

    void Update()
    {
        Vector2 position = transform.position;

        if (Input.GetKey("left"))
        {
            position.x -= speed;
        }
        else if (Input.GetKey("right"))
        {
            position.x += speed;
        }

        transform.position = position;
        if (Input.GetKey("up") && this.jumpCount < 2)
        {
            this.rbody2D.AddForce(transform.up * jumpForce);
            jumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            jumpCount = 0;
        }
    }

    private float speed = 0.01f;
}
