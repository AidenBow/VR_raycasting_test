using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Player : MonoBehaviour
{
    public float playerSpeed = .25f;
    public Vector3 housePosition;
    public Vector3 targetPosition;
    public SteamVR_Input_Sources handType;
    private GameObject rightController;
    private GameObject rightLaser;
    void Start()
    {
        targetPosition = gameObject.transform.parent.position;
        rightController = GameObject.Find("Controller (right)");
        rightLaser = GameObject.Find("rightLaser");
    }

    
    void Update()
    {
        RaycastHit hit; //declare raycast variable
        if (Physics.Raycast(transform.position, transform.forward, out hit)) //draws raycast from player position in the forward direction and outputs hit objects through hit
        {
            if (hit.transform.GetComponent<Button> () != null) //if the hit object is the button
            {
                hit.transform.GetComponent<Button> () .OnLook(); //onlook function from button called
                MoveToHouse();
            }
        }

        gameObject.transform.parent.position = Vector3.Lerp(gameObject.transform.parent.position, targetPosition, Time.deltaTime * playerSpeed);

        bool gripActive = SteamVR_Actions.default_GrabGrip.GetState(handType);
        RaycastHit gripHit;
        if (gripActive)
        {
            if (Physics.Raycast(rightController.transform.position, rightController.transform.forward, out gripHit))
            {
                if (gripHit.transform.GetComponent<Button>() != null) //if the hit object is the button
                {
                    gripHit.transform.GetComponent<Button>().OnLook(); //onlook function from button called
                    MoveToHouse();
                }
            }
            rightLaser.transform.gameObject.SetActive(true);
        }
        else
        {
            rightLaser.transform.gameObject.SetActive(false);
        }
    }

    private void MoveToHouse ()
    {
        targetPosition = housePosition;
    }

}
