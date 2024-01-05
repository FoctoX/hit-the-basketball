using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public BaksetballScript[] gameObjectsWithScript;
    public GameObject pauseButton;
    public GameObject pauseShow;
    public BaksetballScript ballMovement;
    public MateriGameScript materiGameScript;
    public gameplayScript gameplayScript;
    public Transition transition;
    public GameObject mainUI;
    public GameControllerScript gameControllerScript;
    public SoalGameScript soalGameScript;

    public bool pauseSwitch = false;

    private void Awake()
    {
        gameObjectsWithScript = FindObjectsOfType<BaksetballScript>();
        ballMovement = GameObject.FindGameObjectWithTag("BasketballTag").GetComponent<BaksetballScript>();
        gameplayScript = GameObject.FindGameObjectWithTag("GameplayTag").GetComponent<gameplayScript>();
        transition = GameObject.FindGameObjectWithTag("TransitionTag").GetComponent<Transition>();
        materiGameScript = GameObject.FindGameObjectWithTag("MateriGameTag").GetComponent<MateriGameScript>();
        gameControllerScript = GameObject.FindGameObjectWithTag("GameControllerTag").GetComponent<GameControllerScript>();
        soalGameScript = GameObject.FindGameObjectWithTag("SoalGameTag").GetComponent<SoalGameScript>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (pauseSwitch == true)
        {
            pauseShow.SetActive(true);
        }
        if (pauseSwitch == false)
        {
            pauseShow.SetActive(false);
        }
    }

    public void PauseFunction()
    {
        pauseSwitch = !pauseSwitch;
    }

    public void ExitWhileGameplay()
    {
        pauseSwitch = !pauseSwitch;
        pauseShow.SetActive(false);
        gameplayScript.Exit();
        soalGameScript.StopAllCoroutines();
        gameplayScript.StopAllCoroutines();
        materiGameScript.StopAllCoroutines();
        soalGameScript.BackToStart();
        gameplayScript.BackToStart();
        materiGameScript.BackToStart();

        foreach (var gameObj in gameObjectsWithScript)
        {
            gameObj.StopAllCoroutines();
            gameObj.BackToStart();
        }
    }
}
