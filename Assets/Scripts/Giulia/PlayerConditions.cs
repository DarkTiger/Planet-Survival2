using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerConditions : MonoBehaviour {

    public float health = 100.0f;
    public float coef = 0.7f;
    public Text healthText;
    public Text rocketHealthText;

    PlayerInteractions playerInteractions;

    ResourcesPlacement resourcesPlacement;

    private void Start()
    {
        playerInteractions = GetComponent<PlayerInteractions>();

        resourcesPlacement = GameObject.Find("ResourcePlacer").GetComponent<ResourcesPlacement>();
    }

    private void Update()
    {
        if (playerInteractions.playerCamera.enabled && !resourcesPlacement.onInstancing)
        {
            // decreases player's health
            if (health > 0)
            {
                health -= coef * Time.deltaTime;
            }
            else
            {
                health = 0;
            }
            // sets text to health percentage
            healthText.text = "Batteries at " + Mathf.Round(health).ToString() + "%";
        }
        else
        {
            // resets health
            health = 100.0f;
            
            // sets text to health percentage
            rocketHealthText.text = "Batteries at " + Mathf.Round(health).ToString() + "%";
        }


    }
}
