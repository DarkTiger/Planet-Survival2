using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public class GameManager : MonoBehaviour
{
    public float maxTime;
    public GameObject getConditions;
    PlayerConditions playerConditions;
    GameObject player;
    bool isGameOverCalled = false; 
    public Text timeText;
    ResourcesPlacement resourcesPlacement;


    void Start()
    {
        playerConditions = getConditions.GetComponent<PlayerConditions>();
        player = GameObject.Find("Player");

        resourcesPlacement = GameObject.Find("ResourcePlacer").GetComponent<ResourcesPlacement>();
    }


    void Update()
    {
        float healthTemp = playerConditions.health;

        if ((healthTemp <= 0.0f || maxTime <= 0.0f) && !isGameOverCalled)
        {
            GameOver();
        }

        if (!resourcesPlacement.onInstancing)
        {
            if (maxTime > 0)
            {
                maxTime -= Time.deltaTime;
            }
            else
            {
                maxTime = 0;
                playerConditions.health = 0;
            }
        }
       
        timeText.text = (Mathf.FloorToInt(maxTime) / 60).ToString() + ":" + (Mathf.FloorToInt(maxTime) % 60).ToString();
    }


    void GameOver()
    {
        isGameOverCalled = true;

        GameObject animation = player.transform.GetChild(0).gameObject;
        animation.GetComponent<Animator>().enabled = false;

        GameObject camera = player.transform.GetChild(1).gameObject;
        camera.transform.parent = null;

        Rigidbody rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.constraints = RigidbodyConstraints.None;// FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }
}
