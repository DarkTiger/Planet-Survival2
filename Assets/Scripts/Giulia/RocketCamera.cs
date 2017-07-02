using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCamera : MonoBehaviour 
{
	public Camera rocketCamera;
    public Camera playerCamera;
    public GameObject rocketGUI;

    void Start()
    {
        SetPlayerCamera(true);
    }

    void Update()
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

    void SetPlayerCamera(bool isSet)
    {
        playerCamera.enabled = isSet;
        rocketCamera.enabled = !isSet;
        rocketGUI.SetActive(!isSet);
    }
}
