using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    public GameObject character;
	public float speed = 8f;
    public float rotSpeed = 210f;
    private bool isGround;
    private bool isWall;
    
    private Rigidbody rb;

	void Start ()
    {
		rb = gameObject.GetComponent<Rigidbody>();
	}

	void Update () 

	{
        // Move RIGHT
        if (Input.GetKey(KeyCode.D) && isWall == false)
        {
            //transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
            rb.AddTorque(Vector3.up * speed * Time.deltaTime);
        }

        // Move LEFT
        if (Input.GetKey(KeyCode.A) && isWall == false)
        {
            transform.Rotate(-Vector3.up * rotSpeed * Time.deltaTime);
        }

        // Move FOWARD
        if (Input.GetKey(KeyCode.W) && isWall == false)
        {
            //transform.Translate(Vector3.forward * speed * Time.deltaTime);
            //rb.AddForce(Vector3.forward * speed * Time.deltaTime);
            rb.AddRelativeForce(transform.forward * speed, ForceMode.Acceleration);//new Vector3(0, 0, speed);
        }

        // Move BACK
        if (Input.GetKey(KeyCode.S) && isWall == false)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        // JUMP
        if (Input.GetButtonDown("Jump") && isGround == true)
        {
            isGround = false;
            rb.velocity = new Vector3(0, 8f, 0);

        }
	}

    // Jumps only if you are on the ground
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Resource"))
        {
            isGround = true;
        }

        /*if (other.gameObject.CompareTag("Solid"))
        {
            isWall = true;
        }

        else
        {
            isWall = false;
        }*/
    }
        
    void OnCollisionExit(Collision other)
    {
        //isWall = false;
    }


    /*void OnCollisionEnter(Collision other)
    {
        this.transform.position.y = 1;
    }*/
}
