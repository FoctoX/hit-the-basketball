using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainScript : MonoBehaviour
{
    public LogicManager logic;
    public Transition transition;
    public GameObject Camera;
    public GameObject MainUI;
    public GameObject PlayUI;
    public GameObject LevelSelectorUI;
    public GameObject countdown;
    public GameObject soalUI;
    public GameObject soalTambahUI;
    public BaksetballScript ballMovement;
    public CountdownScript countdownScript;
    public gameplayScript gameplayScript;
    public MateriGameScript materiGameScript;
    public PauseScript pauseScript;
    public RedBackgroundScript redBackgroundScript;
    public SoundScript soundScript;

    public GameObject leftHole;
    public GameObject rightHole;

    void Awake()
    {
        soundScript = GameObject.FindGameObjectWithTag("VolumeTag").GetComponent<SoundScript>();
        logic = GameObject.FindGameObjectWithTag("LogicTag").GetComponent<LogicManager>();
        transition = GameObject.FindGameObjectWithTag("TransitionTag").GetComponent<Transition>();
        ballMovement = GameObject.FindGameObjectWithTag("BasketballTag").GetComponent<BaksetballScript>();
        countdownScript = GameObject.FindGameObjectWithTag("CountdownTag").GetComponent<CountdownScript>();
        gameplayScript = GameObject.FindGameObjectWithTag("GameplayTag").GetComponent<gameplayScript>();
        materiGameScript = GameObject.FindGameObjectWithTag("MateriGameTag").GetComponent<MateriGameScript>();
        redBackgroundScript = GameObject.FindGameObjectWithTag("RedBackgroundTag").GetComponent<RedBackgroundScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator MainToLevelSelector()
    {
        transition.AnimationFunction();

        yield return new WaitForSeconds(0.5f);

        MainUI.SetActive(false);
        Camera.transform.position = Camera.transform.position = new Vector3(540, 2880, -1);

        yield return null;
    }

    IEnumerator MainToLevel()
    {
        transition.AnimationFunction();
        countdown.SetActive(true);
        yield return new WaitForSeconds(0.5f);

        redBackgroundScript.InstantChange();
        MainUI.SetActive(false);
        Camera.transform.position = Camera.transform.position = new Vector3(540, 4800, -1);

        yield return null;
    }

    IEnumerator MainToSoal()
    {
        transition.AnimationFunction();
        yield return new WaitForSeconds(0.5f);

        redBackgroundScript.InstantChange();
        MainUI.SetActive(false);
        Camera.transform.position = Camera.transform.position = new Vector3(540, 4800, -1);

        yield return null;
    }

    public void LevelSelector()
    {
        PlayUI.SetActive(false);
        StartCoroutine(MainToLevelSelector());
        LevelSelectorUI.SetActive(true);
    }

    public void playGame()
    {
        soundScript.mainBGM.Stop();
        soundScript.soalBGM.Stop();
        leftHole.transform.localPosition = new Vector3(-415, 0, 0);
        rightHole.transform.localPosition = new Vector3(415, 0, 0);
        StartCoroutine(MainToLevel());
        LevelSelectorUI.SetActive(false);
        gameplayScript.winPage.SetActive(false);
        gameplayScript.winPageUI.SetActive(false);
        gameplayScript.losePage.SetActive(false);
        gameplayScript.losePageUI.SetActive(false);
        materiGameScript.materiCount = 0;
        countdownScript.CountdownStart();
    }

    public void playGameSoal()
    {
        soundScript.mainBGM.Stop();
        soundScript.playBGM.Stop();
        soundScript.soalBGM.Play();
        StartCoroutine(MainToSoal());
        soalUI.SetActive(false);
        soalTambahUI.SetActive(false);
        LevelSelectorUI.SetActive(false);
        countdown.SetActive(false);
        gameplayScript.winPage.SetActive(false);
        gameplayScript.winPageUI.SetActive(false);
        gameplayScript.losePage.SetActive(false);
        gameplayScript.losePageUI.SetActive(false);
    }
}
