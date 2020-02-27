using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = .25f;
    public Vector3 housePosition;
    public Vector3 targetPosition;
    void Start()
    {
        targetPosition = gameObject.transform.parent.position;
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

    }

    private void MoveToHouse ()
    {
        targetPosition = housePosition;
    }

}
