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
    private Animator anim;
    private float jumpTimer = 0;


	void Start ()
    {
		rb = gameObject.GetComponent<Rigidbody>();
        anim = transform.GetChild(0).GetComponent<Animator>();
	}


	void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.up * rotSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if (!anim.GetBool("Jumping") && onGround)
            {
                anim.SetInteger("Speed", 2);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            anim.SetInteger("Speed", 2);
        }

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            if (!anim.GetBool("Jumping"))
            {
                anim.SetInteger("Speed", 0);
            }
        }


        if (Input.GetKey(KeyCode.Space))
        {
            if (onGround)
            {
                rb.AddExplosionForce(jumpSpeed, transform.position, 1);
                anim.SetBool("Jumping", true);
                onGround = false;
            }
        }

        if (jumpTimer > 0.5)
        {
            jumpTimer -= Time.deltaTime;
        }
        else if (anim.GetBool("Jumping"))
        {
           //anim.SetBool("Jumping", false);
        }
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Ground" || other.collider.tag == "Resource")
        {
            onGround = true;
        }
    }
}
