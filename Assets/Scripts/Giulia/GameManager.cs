using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject getConditions;
    PlayerConditions playerConditions;
    GameObject player;


    void Start()
    {
        playerConditions = getConditions.GetComponent<PlayerConditions>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        float healthTemp = playerConditions.health;

        if (healthTemp <= 0.0f)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        GameObject animation = player.transform.GetChild(0).gameObject;
        animation.GetComponent<Animator>().enabled = false;

        GameObject camera = player.transform.GetChild(1).gameObject;
        camera.transform.parent = null;

        Rigidbody rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.constraints = RigidbodyConstraints.None;// FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }
}
