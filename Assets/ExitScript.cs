using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    public LogicManager logicManager;
    public MateriScript materiScript;
    public SoalScript soalScript;
    public gameplayScript gameplayScript;
    public LevelSelectorScript levelSelectorScript;
    public PauseScript pauseScript;

    public Vector3 playPosition = new(540, 960, -1);
    public Vector3 levelSelectorPosition = new(540, 2880, -1);
    public Vector3 gameplayPosition = new(540, 4800, -1);
    public Vector3 materiPosition = new(1620, 960, -1);
    public Vector3 materiTambahanPosition = new(1620, -960, -1);
    public Vector3 materiIsiPosition = new(1620, -2880, -1);
    public Vector3 soalPosition = new(2700, 960, -1);
    public Vector3 soalTambahanPosition = new(2700, -960, -1);
    public Vector3 settingsPosition = new(3780, 960, -1);
    public GameObject exitPopUp;
    public GameObject Camera;
    bool exitPage = false;

    private void Awake()
    {
        logicManager = GameObject.FindGameObjectWithTag("LogicTag").GetComponent<LogicManager>();
        materiScript = GameObject.FindGameObjectWithTag("MateriTag").GetComponent<MateriScript>();
        soalScript = GameObject.FindGameObjectWithTag("SoalTag").GetComponent<SoalScript>();
        gameplayScript = GameObject.FindGameObjectWithTag("GameplayTag").GetComponent<gameplayScript>();
        levelSelectorScript = GameObject.FindGameObjectWithTag("LevelSelectorTag").GetComponent<LevelSelectorScript>();
        pauseScript = GameObject.FindGameObjectWithTag("PauseTag").GetComponent<PauseScript>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Application.platform == RuntimePlatform.Android)
        //{
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (logicManager.pressAble && (Camera.transform.position == playPosition || Camera.transform.position == materiPosition || Camera.transform.position == soalPosition || Camera.transform.position == settingsPosition))
                {
                    exitPage = !exitPage;
                    exitPopUp.SetActive(exitPage);
                }
                if (logicManager.pressAble && (Camera.transform.position == materiTambahanPosition))
                {
                    materiScript.MateriOutNoTransition();
                }
                if (logicManager.pressAble && (Camera.transform.position == materiIsiPosition))
                {
                    materiScript.MateriOut();
                }
                if (logicManager.pressAble && (Camera.transform.position == soalTambahanPosition))
                {
                    soalScript.SoalOut();
                }
                if (logicManager.pressAble && (Camera.transform.position == levelSelectorPosition))
                {
                    levelSelectorScript.LevelSelectorExit();
                }
                if (logicManager.pressAble && (Camera.transform.position == gameplayPosition))
                {
                    pauseScript.PauseFunction();
                }
            }
        //}
    }

    public void CloseExit()
    {
        exitPage = !exitPage;
        exitPopUp.SetActive(exitPage);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}