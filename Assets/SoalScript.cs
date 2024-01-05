using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoalScript : MonoBehaviour
{
    Vector3 soalPosition;
    Vector3 soalTambahPosition;
    Vector3 cameraPosition;

    [SerializeField]
    private AnimationCurve SoalTambahCurve;
    public Transition transition;
    public SoalGameScript soalGameScript;
    public LevelSelectorScript levelSelectorScript;
    public MainScript mainScript;
    public LogicManager logicManager;

    public GameObject Camera;
    public GameObject mainUI;
    public GameObject navbar;
    public GameObject navbarUI;
    public GameObject soalUI;
    public GameObject soalTambahUI;

    public bool soalSoloPlayed;

    private void Awake()
    {
        soalPosition = new Vector3(2700, 960, -1);
        soalTambahPosition = new Vector3(2700, -960, -1);
        transition = GameObject.FindGameObjectWithTag("TransitionTag").GetComponent<Transition>();
        soalGameScript = GameObject.FindGameObjectWithTag("SoalGameTag").GetComponent<SoalGameScript>();
        levelSelectorScript = GameObject.FindGameObjectWithTag("LevelSelectorTag").GetComponent<LevelSelectorScript>();
        mainScript = GameObject.FindGameObjectWithTag("MainMenuTag").GetComponent<MainScript>();
        logicManager = GameObject.FindGameObjectWithTag("LogicTag").GetComponent<LogicManager>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoalSejarahScene()
    {
        if (logicManager.pressAble)
        {
            soalGameScript.PlaySoalWithoutGameplay();
            levelSelectorScript.levelPlayed = 1;
            soalGameScript.soalLife = 3;
            soalGameScript.soalPoint = 0;
            soalGameScript.soalTarget = 3;
            soalUI.SetActive(false);
            soalTambahUI.SetActive(false);
            soalSoloPlayed = true;
            mainScript.playGameSoal();
        }
    }

    public void SoalTeknikScene()
    {
        if (logicManager.pressAble)
        {
            SoalTambahScene();
        }
    }

    public void SoalPassingScene()
    {
        if (logicManager.pressAble)
        {
            soalGameScript.PlaySoalWithoutGameplay();
            levelSelectorScript.levelPlayed = 2;
            soalGameScript.soalLife = 3;
            soalGameScript.soalPoint = 0;
            soalGameScript.soalTarget = 4;
            soalUI.SetActive(false);
            soalTambahUI.SetActive(false);
            soalSoloPlayed = true;
            mainScript.playGameSoal();
        }
    }

    public void SoalDribbleScene()
    {
        if (logicManager.pressAble)
        {
            soalGameScript.PlaySoalWithoutGameplay();
            levelSelectorScript.levelPlayed = 3;
            soalGameScript.soalLife = 3;
            soalGameScript.soalPoint = 0;
            soalGameScript.soalTarget = 3;
            soalUI.SetActive(false);
            soalTambahUI.SetActive(false);
            soalSoloPlayed = true;
            mainScript.playGameSoal();
        }
    }

    public void SoalShootingScene()
    {
        if (logicManager.pressAble)
        {
            soalGameScript.PlaySoalWithoutGameplay();
            levelSelectorScript.levelPlayed = 4;
            soalGameScript.soalLife = 3;
            soalGameScript.soalPoint = 0;
            soalGameScript.soalTarget = 5;
            soalUI.SetActive(false);
            soalTambahUI.SetActive(false);
            soalSoloPlayed = true;
            mainScript.playGameSoal();
        }
    }

    public void SoalLainnyaScene()
    {
        if (logicManager.pressAble)
        {
            soalGameScript.PlaySoalWithoutGameplay();
            levelSelectorScript.levelPlayed = 5;
            soalGameScript.soalLife = 3;
            soalGameScript.soalPoint = 0;
            soalGameScript.soalTarget = 3;
            soalUI.SetActive(false);
            soalTambahUI.SetActive(false);
            soalSoloPlayed = true;
            mainScript.playGameSoal();
        }
    }

    public void SoalAturanScene()
    {
        if (logicManager.pressAble)
        {
            soalGameScript.PlaySoalWithoutGameplay();
            levelSelectorScript.levelPlayed = 6;
            soalGameScript.soalLife = 3;
            soalGameScript.soalPoint = 0;
            soalGameScript.soalTarget = 5;
            soalUI.SetActive(false);
            soalTambahUI.SetActive(false);
            soalSoloPlayed = true;
            mainScript.playGameSoal();
        }
    }

    public void SoalTambahScene()
    {
        if (logicManager.pressAble)
        {
            cameraPosition = Camera.transform.position;
            StartCoroutine(Animation(Camera, cameraPosition, soalTambahPosition));
            navbar.SetActive(false);
            navbarUI.SetActive(false);
            soalTambahUI.SetActive(true);
        }
    }

    public void SoalOut()
    {
        if (logicManager.pressAble)
        {
            cameraPosition = Camera.transform.position;
            StartCoroutine(Animation(Camera, cameraPosition, soalPosition));
            navbar.SetActive(true);
            navbarUI.SetActive(true);
            soalTambahUI.SetActive(false);
            soalSoloPlayed = false;
        }
    }

    IEnumerator Animation(GameObject navbar, Vector3 start, Vector3 end)
    {
        logicManager.pressAble = false;
        float duration = 1f;
        float elapsedTime = 0f;
        float percentageComplete = 0f;

        while (percentageComplete < 1f)
        {
            elapsedTime += Time.deltaTime;
            percentageComplete = elapsedTime / duration;

            navbar.transform.localPosition = Vector3.Lerp(start, end, SoalTambahCurve.Evaluate(percentageComplete));
            yield return null;
        }

        navbar.transform.localPosition = end;
        logicManager.pressAble = true;
    }
}
