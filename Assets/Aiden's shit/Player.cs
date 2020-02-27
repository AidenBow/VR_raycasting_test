using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit; //declare raycast variable
        if (Physics.Raycast(transform.position, transform.forward, out hit)) //draws raycast from player position in the forward direction and outputs hit objects through hit
        {
            if (hit.transform.GetComponent<Button> () != null) //if the hit object is the button
            {
                hit.transform.GetComponent<Button> () .OnLook(); //onlook function from button called
            }
        }
    }
}
