using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCameraAndGUI : MonoBehaviour {

    public GameObject playerGUI;
    
    // Resources carried by the player
    public int playerSteelCount = 0;
    public int playerCircuitsCount = 0;
    public int playerUraniumCount = 0;
    public int playerPlasticCount = 0;
    public int playerGlassCount = 0;
    public int playerFuelCount = 0;

    // Text displaying resources currently carried by the player
    public Text playerSteelText;
    public Text playerCircuitsText;
    public Text playerUraniumText;
    public Text playerPlasticText;
    public Text playerGlassText;
    public Text playerFuelText;
    
    private void Update()
    {
        // GUI change between the two cameras
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (playerGUI.activeSelf)
            {
                playerGUI.SetActive(false);
            }
            else
            {
                playerGUI.SetActive(true);
            }
        }

        // Update of the text in the player GUI
        playerSteelText.text = playerSteelCount.ToString();
        playerCircuitsText.text = playerCircuitsCount.ToString();
        playerUraniumText.text = playerUraniumCount.ToString();
        playerPlasticText.text = playerPlasticCount.ToString();
        playerGlassText.text = playerGlassCount.ToString();
        playerFuelText.text = playerFuelCount.ToString();
    }
}
