using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed;
    public float rotSpeed;
    public float jumpSpeed;
    private bool onGround;
    private Rigidbody rb;


	void Start ()
    {
		rb = gameObject.GetComponent<Rigidbody>();
	}


	void Update () 
	{
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
        }

        // Move LEFT
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.up * rotSpeed * Time.deltaTime);
        }

        // Move FOWARD
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        // Move BACK
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (onGround)
            {
                rb.AddExplosionForce(jumpSpeed, transform.position, 1);
                onGround = false;
            }
        }
    }

    // Jumps only if you are on the ground
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Ground" || other.collider.tag == "Resource")
        {
            onGround = true;
        }
    }
}
