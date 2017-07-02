using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    public GameObject character;
	public float speed = 8f;
    private bool isGround;
    private bool isWall;
    bool rotRight = false;



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

        if (rotRight && transform.rotation.y != 90)
        {
            //rotRight = false;
            //Quaternion rotationPlayer = transform.rotation;
            //rotationPlayer.y = 90;
            transform.Rotate(new Vector3(0, 1, 0), 5f);
            Debug.Log(transform.rotation.y);
            //= rotationPlayer;//Quaternion.Lerp(transform.rotation, rotationPlayer, 0.003f);
        }
        else
        {

            rotRight = false;
            //Debug.Log("false");
        }

        if (Input.GetKey(KeyCode.A) && isWall == false) // Move LEFT
        {
            transform.position += Vector3.left * speed * Time.deltaTime;

        }

        if (Input.GetKey(KeyCode.W) && isWall == false) // Move UP
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
            
        }

        if (Input.GetKey(KeyCode.S) && isWall == false) // Move DOWN
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
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
