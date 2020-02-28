using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public TextMesh infoText;
    public Player player;
    public Transform enemyContainer;
    void Start()
    {
        infoText.text = "shoot the button";
    }

    // Update is called once per frame
    void Update()
    {
        if (player.enteredCastle)
        {
            int enemiesRemaining = enemyContainer.transform.childCount;
            Debug.Log(enemiesRemaining);

            infoText.text = "shoot the balls bro";
            infoText.text += "\n only " + enemiesRemaining + " to kill!";

            if (enemiesRemaining <= 0)
            {
                infoText.text = "well done mate";
            }
        }
    }
}
