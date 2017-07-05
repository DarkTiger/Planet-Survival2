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
            else if (hit.collider.tag == "Resource")
            {
               GameObject resource = hit.collider.gameObject;

               PlayerCameraAndGUI inventory = GetComponent<PlayerCameraAndGUI>();
               ResourcesQuantity resCount = new ResourcesQuantity();
               resCount = resource.GetComponent<ResourcesQuantity>();

               inventory.playerSteelCount += resCount.steelCount;
               inventory.playerCircuitsCount += resCount.circuitsCount;
               inventory.playerUraniumCount += resCount.uraniumCount;
               inventory.playerPlasticCount += resCount.plasticCount;
               inventory.playerGlassCount += resCount.glassCount;
               inventory.playerFuelCount += resCount.fuelCount;

               Destroy(resource);
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
