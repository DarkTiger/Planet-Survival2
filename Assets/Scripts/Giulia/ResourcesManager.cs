using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesManager : MonoBehaviour 
{

    public int steelCount = 0;
    public int circuitsCount = 0;
    public int uraniumCount = 0;
    public int plasticCount = 0;
    public int glassCount = 0;
    public int fuelCount = 0;

    public Text steelCountText;
    public Text circuitsCountText;
    public Text uraniumCountText;
    public Text plasticCountText;
    public Text glassCountText;
    public Text fuelCountText;

    void Update()
    {
        steelCountText.text = steelCount.ToString();
        circuitsCountText.text = circuitsCount.ToString();
        uraniumCountText.text = uraniumCount.ToString();
        plasticCountText.text = plasticCount.ToString();
        glassCountText.text = glassCount.ToString();
        fuelCountText.text = fuelCount.ToString();
    }



}
