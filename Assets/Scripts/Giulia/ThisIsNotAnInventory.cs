using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisIsNotAnInventory : MonoBehaviour 
{
    GameObject player;

    public float grabRange;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(player.transform.position, Vector3.forward, out hit, grabRange))
        {
            if (hit.collider.tag == "ResourceSteel")
            {
                
            }
        }
    }
    

}
