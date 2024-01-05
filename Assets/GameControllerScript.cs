using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public BaksetballScript[] gameObjectsWithScript;
    public CountdownScript countdownScript;

    private void Start()
    {
        gameObjectsWithScript = FindObjectsOfType<BaksetballScript>();
        countdownScript = GameObject.FindGameObjectWithTag("CountdownTag").GetComponent<CountdownScript>();
    }

    public void StartGameObjectsWithCondition()
    {
        foreach (var gameObj in gameObjectsWithScript)
        {
            if (countdownScript.startGameSwitch == true)
            {
                gameObj.startGame();
                gameObj.EnemyType();
            }
        }
    }
}

