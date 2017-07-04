using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour 
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

        if (Physics.Raycast(transform.position, transform.forward, out hit, grabRange))
        {
            Debug.Log(hit.collider.tag);
            /*if (hit.collider.tag == "ResourceSteel")
            {
                
            }*/
        }
    }
}
