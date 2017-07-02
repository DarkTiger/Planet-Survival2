using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    public GameObject character;
	public float speed = 8f;
    private bool isGround;
    private bool isWall;
    bool rotRight = false;
    bool rotLeft = false;
    bool rotFoward = false;
    bool rotBack = false;



    private Rigidbody rb;

	void Start () {

		rb = gameObject.GetComponent<Rigidbody>();
		
	}

	void Update () 

	{
        


        if (Input.GetKey(KeyCode.D) && isWall == false) // Move RIGHT
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            rotRight = true;
        }

        if (rotRight)
        {
            transform.eulerAngles = new Vector3(0, 90, 0); // Rotate RIGHT
            rotRight = false;
        }

        if (Input.GetKey(KeyCode.A) && isWall == false) // Move LEFT
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            rotLeft = true;
        }
        if (rotLeft)
        {
            transform.eulerAngles = new Vector3(0, -90, 0); // Rotate LEFT
            rotLeft = false;
        }

        if (Input.GetKey(KeyCode.W) && isWall == false) // Move FOWARD
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
            rotFoward = true;
        }

        if (rotFoward)
        {
            transform.eulerAngles = new Vector3(0, 0, 0); // Rotate FOWARD
            rotFoward = false;
        }

        if (Input.GetKey(KeyCode.S) && isWall == false) // Move BACK
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
            rotBack = true;
        }
        if (rotBack)
        {
            transform.eulerAngles = new Vector3(0, 180, 0); // Rotate BACK
            rotBack = false;
        }

        if (Input.GetButtonDown("Jump") && isGround == true) // JUMP
        {
            isGround = false;
            rb.velocity = new Vector3(0, 8f, 0);

        }

        /*if (this.transform.rotation.x != 0) // Make the player Stays on X position
        {
            Quaternion rot = transform.rotation;
            rot.x = 0;
            rot.y = 0;
            rot.z = 0;
            transform.rotation = rot;
        }*/

	}

    void OnCollisionEnter(Collision other) // Jumps only if you are on the ground
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }

        if (other.gameObject.CompareTag("Solid"))
        {
            isWall = true;
        }

        else
        {
            isWall = false;
        }
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
