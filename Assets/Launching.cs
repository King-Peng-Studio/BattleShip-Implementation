using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Launching : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClick()
    {
        GetComponent<Image>().sprite = Resources.Load<Sprite>("MissedShip");

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
