using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Vector3 loweredPosition;
    public Vector3 targetPosition;
    void Start()
    {
        targetPosition = gameObject.transform.localPosition; // keeps door in starting position
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localPosition = Vector3.Lerp(gameObject.transform.localPosition, targetPosition, Time.deltaTime); //moves door to target position
    }

    public void LowerDoor ()
    {
        targetPosition = loweredPosition; //sets target position to lowered position
    }
}
