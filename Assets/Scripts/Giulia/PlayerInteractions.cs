using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour 
{
    public float grabRange;
    public Camera rocketCamera;
    public Camera playerCamera;
    public GameObject rocketGUI;
    public GameObject playerGUI;

    PlayerMovement playerMovement;


    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }


    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, grabRange))
        {
            if (hit.collider.tag == "Rocket")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (rocketCamera.enabled)
                    {
                        SetPlayerCamera(true);
                    }
                    else
                    {
                        SetPlayerCamera(false);
                    }                     
                }  
            }
        }
    }

    void SetPlayerCamera(bool isSet)
    {
        playerCamera.enabled = isSet;
        rocketCamera.enabled = !isSet;
        rocketGUI.SetActive(!isSet);
        playerGUI.SetActive(isSet);
        playerMovement.enabled = isSet;
    }
}
