using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class gameplayScript : MonoBehaviour
{
    Vector3 leftHoleStartPosition = new Vector3(-415, 0, 0);
    Vector3 leftHoleEndPosition = new Vector3(0, 0, 0);
    Vector3 rightHoleStartPosition = new Vector3(415, 0, 0);
    Vector3 rightHoleEndPosition = new Vector3(0, 0, 0);
    Vector3 pageStartScale = new Vector3(0, 0, 0);
    Vector3 pageEndScale = new Vector3(1, 1, 1);

    float elapsed;
    float duration = 1.5f;

    [SerializeField]
    private AnimationCurve curve;

    public GameObject Camera;
    public GameObject mainUI;
    public GameObject Navbar;
    public GameObject NavbarUI;
    public GameObject playUI;
    public GameObject gameplayUI;
    public GameObject backgroundRed;
    public GameObject ballBoss;
    public GameObject soalGame;
    public GameObject soalUI;
    public Text materiCountUI;
    public Text materiTargetUI;
    public RedBackgroundScript redBackgroundScript;
    public MateriGameScript materiGameScript;
    public SoalGameScript soalGameScript;
    public PauseScript pauseScript;
    public LevelSelectorScript levelSelectorScript;
    public Transition transition;
    public CountdownScript countdownScript;
    public BaksetballScript baksetballScript;
    public SoalScript soalScript;
    public SoundScript soundScript;
    public TutorialScript tutorialScript;

    public GameObject pauseUI;

    public GameObject winPage;
    public GameObject winPageUI;
    public GameObject losePage;
    public GameObject losePageUI;
    public GameObject previousBtn;
    public GameObject previousUIBtn;
    public GameObject nextBtn;
    public GameObject nextUIBtn;
    public GameObject retryBtn;
    public GameObject retryUIBtn;
    public GameObject retryBtn2;
    public GameObject retryUIBtn2;

    public GameObject leftHole;
    public GameObject rightHole;

    public GameProgress gameProgress;

    public GameObject newWin;
    public GameObject oldWin;

    public bool boolBossStage = false;
    public bool gameplaySwitch = false;

    private void Awake()
    {
        pauseScript = GameObject.FindGameObjectWithTag("PauseTag").GetComponent<PauseScript>();
        materiGameScript = GameObject.FindGameObjectWithTag("MateriGameTag").GetComponent<MateriGameScript>();
        soalGameScript = GameObject.FindGameObjectWithTag("SoalGameTag").GetComponent<SoalGameScript>();
        levelSelectorScript = GameObject.FindGameObjectWithTag("LevelSelectorTag").GetComponent<LevelSelectorScript>();
        countdownScript = GameObject.FindGameObjectWithTag("CountdownTag").GetComponent<CountdownScript>();
        transition = GameObject.FindGameObjectWithTag("TransitionTag").GetComponent<Transition>();
        baksetballScript = GameObject.FindGameObjectWithTag("BasketballTag").GetComponent<BaksetballScript>();
        soalScript = GameObject.FindGameObjectWithTag("SoalTag").GetComponent<SoalScript>();
        soundScript = GameObject.FindGameObjectWithTag("VolumeTag").GetComponent<SoundScript>();
        tutorialScript = GameObject.FindGameObjectWithTag("GameplayTag").GetComponent<TutorialScript>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SaveAndLoadScript.SaveGame(gameProgress);

        materiCountUI.text = materiGameScript.materiCount.ToString();


        if (levelSelectorScript.levelPlayed == 1)
        {
            materiTargetUI.text = "/3";
        }
        if (levelSelectorScript.levelPlayed == 2)
        {
            materiTargetUI.text = "/4";
        }
        if (levelSelectorScript.levelPlayed == 3)
        {
            materiTargetUI.text = "/3";
        }
        if (levelSelectorScript.levelPlayed == 4)
        {
            materiTargetUI.text = "/5";
        }
        if (levelSelectorScript.levelPlayed == 5)
        {
            materiTargetUI.text = "/3";
        }
        if (levelSelectorScript.levelPlayed == 6)
        {
            materiTargetUI.text = "/7";
        }

        /*
        if (pauseScript.pauseSwitch == true)
        {
            Time.timeScale = 0;
        }else
        {
            Time.timeScale = 1;
        }*/
    }

    public void BackToStart()
    {
        leftHole.transform.localPosition = leftHoleStartPosition;
        rightHole.transform.localPosition = rightHoleStartPosition;
    }

    public void HoleStart()
    {
        StartCoroutine(Animation(leftHole, leftHoleStartPosition, leftHoleEndPosition, true));
        StartCoroutine(Animation(rightHole, rightHoleStartPosition, rightHoleEndPosition, true));
    }

    public void HoleEnd()
    {
        StartCoroutine(Animation(leftHole, leftHoleEndPosition, leftHoleStartPosition, false));
        StartCoroutine(Animation(rightHole, rightHoleEndPosition, rightHoleStartPosition, false));
        gameplayUI.SetActive(false);
    }

    public void WinPageShow()
    {
        soundScript.winPageSound.Play();
        pauseUI.SetActive(false);
        winPage.SetActive(true);
        winPageUI.SetActive(true);
        Win();
        StartCoroutine(AnimationScale(winPage, pageStartScale, pageEndScale));
    }

    public void LosePageShow()
    {
        soundScript.losePageSound.Play();
        losePage.SetActive(true);
        losePageUI.SetActive(true);
        if (soalScript.soalSoloPlayed == false)
        {
            retryBtn2.SetActive(true);
            retryUIBtn2.SetActive(true);
            pauseUI.SetActive(false);
            losePage.SetActive(true);
            losePageUI.SetActive(true);
        }
        if (soalScript.soalSoloPlayed == true)
        {
            DisableResultButton();
        }
        StartCoroutine(AnimationScale(losePage, pageStartScale, pageEndScale));
    }

    IEnumerator Animation(GameObject subject, Vector3 start, Vector3 end, bool tutorial)
    {
        float percentage = 0;
        elapsed = 0;
        while (percentage < duration)
        {
            elapsed += Time.deltaTime;
            percentage = elapsed / duration;

            subject.transform.localPosition = Vector3.Lerp(start, end, curve.Evaluate(percentage));

            yield return null;
        }
        if (tutorial)
        {
            tutorialScript.TutorialShow();
        }
        subject.transform.localPosition = end;
    }

    IEnumerator AnimationScale(GameObject subject, Vector3 start, Vector3 end)
    {
        float percentage = 0;
        elapsed = 0;
        while (percentage < duration)
        {
            elapsed += Time.deltaTime;
            percentage = elapsed / duration;

            subject.transform.localScale = Vector3.Lerp(start, end, curve.Evaluate(percentage));

            yield return null;
        }
        subject.transform.localScale = end;
    }

    public void DisableResultButton()
    {
        previousBtn.SetActive(false);
        previousUIBtn.SetActive(false);
        nextBtn.SetActive(false);
        nextUIBtn.SetActive(false);
        retryBtn.SetActive(false);
        retryUIBtn.SetActive(false);
        retryBtn2.SetActive(false);
        retryUIBtn2.SetActive(false);
        newWin.SetActive(false);
        oldWin.SetActive(true);
    }

    [ContextMenu("UnlockLevel")]
    public void Win()
    {
        switch (levelSelectorScript.levelPlayed)
        {
            case 1:
                if (soalScript.soalSoloPlayed == false && !levelSelectorScript.level1Complete)
                {
                    newWin.SetActive(true);
                    oldWin.SetActive(false);
                    previousBtn.SetActive(false);
                    previousUIBtn.SetActive(false);
                    nextBtn.SetActive(true);
                    nextUIBtn.SetActive(true);
                    retryBtn.SetActive(true);
                    retryUIBtn.SetActive(true);
                    levelSelectorScript.Level1Complete();
                }
                else if (soalScript.soalSoloPlayed == false && levelSelectorScript.level1Complete)
                {
                    previousBtn.SetActive(false);
                    previousUIBtn.SetActive(false);
                    nextBtn.SetActive(true);
                    nextUIBtn.SetActive(true);
                    oldWin.SetActive(true);
                    newWin.SetActive(false);
                    retryBtn.SetActive(true);
                    retryUIBtn.SetActive(true);
                }
                else if (soalScript.soalSoloPlayed == true)
                {
                    DisableResultButton();
                }
                break;

            case 2:
                if (soalScript.soalSoloPlayed == false && !levelSelectorScript.level2Complete)
                {
                    newWin.SetActive(true);
                    oldWin.SetActive(false);
                    previousBtn.SetActive(true);
                    previousUIBtn.SetActive(true);
                    nextBtn.SetActive(true);
                    nextUIBtn.SetActive(true);
                    retryBtn.SetActive(true);
                    retryUIBtn.SetActive(true);
                    levelSelectorScript.Level2Complete();
                }
                else if (soalScript.soalSoloPlayed == false && levelSelectorScript.level2Complete)
                {
                    previousBtn.SetActive(true);
                    previousUIBtn.SetActive(true);
                    nextBtn.SetActive(true);
                    nextUIBtn.SetActive(true);
                    oldWin.SetActive(true);
                    newWin.SetActive(false);
                    retryBtn.SetActive(true);
                    retryUIBtn.SetActive(true);
                }
                else if (soalScript.soalSoloPlayed == true)
                {
                    DisableResultButton();
                }
                break;

            case 3:
                if (soalScript.soalSoloPlayed == false && !levelSelectorScript.level3Complete)
                {
                    newWin.SetActive(true);
                    oldWin.SetActive(false);
                    previousBtn.SetActive(true);
                    previousUIBtn.SetActive(true);
                    nextBtn.SetActive(true);
                    nextUIBtn.SetActive(true);
                    retryBtn.SetActive(true);
                    retryUIBtn.SetActive(true);
                    levelSelectorScript.Level3Complete();
                }
                else if (soalScript.soalSoloPlayed == false && levelSelectorScript.level3Complete)
                {
                    newWin.SetActive(true);
                    previousBtn.SetActive(true);
                    previousUIBtn.SetActive(true);
                    nextBtn.SetActive(true);
                    nextUIBtn.SetActive(true);
                    oldWin.SetActive(true);
                    newWin.SetActive(false);
                    retryBtn.SetActive(true);
                    retryUIBtn.SetActive(true);
                }
                else if (soalScript.soalSoloPlayed == true)
                {
                    DisableResultButton();
                }
                break;

            case 4:
                if (soalScript.soalSoloPlayed == false && !levelSelectorScript.level4Complete)
                {
                    newWin.SetActive(true);
                    oldWin.SetActive(false);
                    previousBtn.SetActive(true);
                    previousUIBtn.SetActive(true);
                    nextBtn.SetActive(true);
                    nextUIBtn.SetActive(true);
                    retryBtn.SetActive(true);
                    retryUIBtn.SetActive(true);
                    levelSelectorScript.Level4Complete();
                }
                else if (soalScript.soalSoloPlayed == false && levelSelectorScript.level4Complete)
                {
                    previousBtn.SetActive(true);
                    previousUIBtn.SetActive(true);
                    nextBtn.SetActive(true);
                    nextUIBtn.SetActive(true);
                    oldWin.SetActive(true);
                    newWin.SetActive(false);
                    retryBtn.SetActive(true);
                    retryUIBtn.SetActive(true);
                }
                else if (soalScript.soalSoloPlayed == true)
                {
                    DisableResultButton();
                }
                break;

            case 5:
                if (soalScript.soalSoloPlayed == false && !levelSelectorScript.level5Complete)
                {
                    newWin.SetActive(true);
                    oldWin.SetActive(false);
                    previousBtn.SetActive(true);
                    previousUIBtn.SetActive(true);
                    nextBtn.SetActive(true);
                    nextUIBtn.SetActive(true);
                    retryBtn.SetActive(true);
                    retryUIBtn.SetActive(true);
                    levelSelectorScript.Level5Complete();
                }
                else if (soalScript.soalSoloPlayed == false && levelSelectorScript.level5Complete)
                {
                    previousBtn.SetActive(true);
                    previousUIBtn.SetActive(true);
                    nextBtn.SetActive(true);
                    nextUIBtn.SetActive(true);
                    oldWin.SetActive(true);
                    newWin.SetActive(false);
                    retryBtn.SetActive(true);
                    retryUIBtn.SetActive(true);
                }
                else if (soalScript.soalSoloPlayed == true)
                {
                    DisableResultButton();
                }
                break;

            case 6:
                if (soalScript.soalSoloPlayed == false && !levelSelectorScript.level6Complete)
                {
                    newWin.SetActive(true);
                    oldWin.SetActive(false);
                    previousBtn.SetActive(true);
                    previousUIBtn.SetActive(true);
                    nextBtn.SetActive(false);
                    nextUIBtn.SetActive(false);
                    retryBtn.SetActive(true);
                    retryUIBtn.SetActive(true);
                    levelSelectorScript.Level6Complete();
                }
                else if (soalScript.soalSoloPlayed == false && levelSelectorScript.level6Complete)
                {
                    previousBtn.SetActive(true);
                    previousUIBtn.SetActive(true);
                    nextBtn.SetActive(false);
                    nextUIBtn.SetActive(false);
                    oldWin.SetActive(true);
                    newWin.SetActive(false);
                    retryBtn.SetActive(true);
                    retryUIBtn.SetActive(true);
                }
                else if (soalScript.soalSoloPlayed == true)
                {
                    DisableResultButton();
                }
                break;
        }
    }

    public void Exit()
    {
        materiGameScript.materiPause = false;
        gameplaySwitch = false;
        transition.AnimationFunction();
        Invoke("CameraExitToMainMenu", 0.5f);
        soalGameScript.StopAllCoroutines();
        baksetballScript.StopAllCoroutines();
        StopAllCoroutines();
    }

    public void CameraExitToMainMenu()
    {
        if (soalScript.soalSoloPlayed == false)
        {
            soundScript.mainBGM.Play();
            soundScript.soalBGM.Stop();
            soundScript.playBGM.Stop();
            Camera.transform.position = new Vector3(540, 960, -1);
            pauseUI.SetActive(false);
            gameplayUI.SetActive(false);
            winPage.SetActive(false);
            winPageUI.SetActive(false);
            losePage.SetActive(false);
            losePageUI.SetActive(false);
            playUI.SetActive(true);
            mainUI.SetActive(true);
            Navbar.SetActive(true);
            NavbarUI.SetActive(true);
        }

        if (soalScript.soalSoloPlayed == true)
        {
            soundScript.mainBGM.Play();
            soundScript.soalBGM.Stop();
            soundScript.playBGM.Stop();
            Camera.transform.position = new Vector3(2700, 960, -1);
            pauseUI.SetActive(false);
            gameplayUI.SetActive(false);
            winPage.SetActive(false);
            winPageUI.SetActive(false);
            losePage.SetActive(false);
            losePageUI.SetActive(false);
            soalUI.SetActive(true);
            mainUI.SetActive(true);
            Navbar.SetActive(true);
            NavbarUI.SetActive(true);
            soalScript.soalSoloPlayed = false;
        }
    }

    public void Retry()
    {
        switch (levelSelectorScript.levelPlayed)
        {
            case 1:
                levelSelectorScript.Level1Enter();
                break;
            case 2:
                levelSelectorScript.Level2Enter();
                break;
            case 3:
                levelSelectorScript.Level3Enter();
                break;
            case 4:
                levelSelectorScript.Level4Enter();
                break;
            case 5:
                levelSelectorScript.Level5Enter();
                break;
            case 6:
                levelSelectorScript.Level6Enter();
                break;
        }
    }

    public void Previous()
    {
        switch (levelSelectorScript.levelPlayed)
        {
            case 2:
                levelSelectorScript.Level1Enter();
                break;
            case 3:
                levelSelectorScript.Level2Enter();
                break;
            case 4:
                levelSelectorScript.Level3Enter();
                break;
            case 5:
                levelSelectorScript.Level4Enter();
                break;
            case 6:
                levelSelectorScript.Level5Enter();
                break;
        }
    }

    public void Next()
    {
        switch (levelSelectorScript.levelPlayed)
        {
            case 1:
                levelSelectorScript.Level2Enter();
                break;
            case 2:
                levelSelectorScript.Level3Enter();
                break;
            case 3:
                levelSelectorScript.Level4Enter();
                break;
            case 4:
                levelSelectorScript.Level5Enter();
                break;
            case 5:
                levelSelectorScript.Level6Enter();
                break;
        }
    }
}
