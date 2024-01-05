using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;
using System;

//using UnityEditor.UIElements;

public class LogicManager : MonoBehaviour
{
    // Navbar
    public GameObject MainMenuNavbar;
    public GameObject MateriNavbar;
    public GameObject SoalNavbar;
    public GameObject SettingsNavbar;
    public bool mainMenuScene = false;
    public bool materiScene = false;
    public bool soalScene = false;
    public bool settingsScene = false;

    // Navbar Movement
    public float duration;
    float elapsedTime;
    Vector3 mainMenuStartPosition;
    Vector3 mainMenuEndPosition;
    Vector3 materiStartPosition;
    Vector3 materiEndPosition;
    Vector3 soalStartPosition;
    Vector3 soalEndPosition;
    Vector3 settingsStartPosition;
    Vector3 settingsEndPosition;

    [SerializeField]
    private AnimationCurve curve;

    // UI
    public GameObject MainUI;
    public GameObject MateriUI;
    public GameObject SoalUI;
    public GameObject SettingsUI;
    public GameObject SettingsSFX;
    public GameObject SettingsBGM;

    // Camera
    public GameObject Camera;
    Vector3 cameraPosition;
    Vector3 mainMenuPosition;
    Vector3 materiPosition;
    Vector3 soalPosition;
    Vector3 soalTambahPosition;
    Vector3 settingsPosition;

    // Switch
    bool MainButtonActivated = true;
    bool MateriButtonActivated = true;
    bool SoalButtonActivated = true;
    bool SettingsButtonActivated = true;

    public GameProgress gameProgress;
    public SoundScript soundScript;

    public bool pressAble = true;

    private void Awake()
    {
        Application.targetFrameRate = 120;
        gameProgress = new GameProgress();

        soundScript = GameObject.FindGameObjectWithTag("VolumeTag").GetComponent<SoundScript>();
        cameraPosition = Camera.transform.position;
        mainMenuStartPosition = MainMenuNavbar.transform.localPosition;
        mainMenuEndPosition = new Vector3(MainMenuNavbar.transform.localPosition.x, MainMenuNavbar.transform.localPosition.y + 100, MainMenuNavbar.transform.localPosition.z);
        materiStartPosition = MateriNavbar.transform.localPosition;
        materiEndPosition = new Vector3(MateriNavbar.transform.localPosition.x, MateriNavbar.transform.localPosition.y + 100, MateriNavbar.transform.localPosition.z);
        soalStartPosition = SoalNavbar.transform.localPosition;
        soalEndPosition = new Vector3(SoalNavbar.transform.localPosition.x, SoalNavbar.transform.localPosition.y + 100, SoalNavbar.transform.localPosition.z);
        settingsStartPosition = SettingsNavbar.transform.localPosition;
        settingsEndPosition = new Vector3(SettingsNavbar.transform.localPosition.x, SettingsNavbar.transform.localPosition.y + 100, SettingsNavbar.transform.localPosition.z);
        mainMenuPosition = new Vector3(540, 960, -1);
        materiPosition = new Vector3(1620, 960, -1);
        soalPosition = new Vector3(2700, 960, -1);
        soalTambahPosition = new Vector3(2700, -960, -1);
        settingsPosition = new Vector3(3780, 960, -1);

        mainMenuSceneEnabled();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameProgress = SaveAndLoadScript.LoadGame();
        if (gameProgress == null)
        {
            gameProgress = new GameProgress();
        }
    }
    // Update is called once per frame
    void Update()
    {
        cameraPosition = Camera.transform.position;
    }


    // Boolean Scene
    public void mainMenuSceneEnabled()
    {
        if (MainButtonActivated == true && pressAble == true)
        {
            soundScript.buttonClickSound.Play();
            MainUI.SetActive(true);
            MateriUI.SetActive(false);
            SoalUI.SetActive(false);
            SettingsUI.SetActive(false);
            MainButtonActivated = false;
            mainMenuScene = true;
            StartCoroutine(Animation(MainMenuNavbar, mainMenuStartPosition, mainMenuEndPosition));
            StartCoroutine(Animation(Camera, cameraPosition, mainMenuPosition));
            MateriButtonActivated = true;
            SoalButtonActivated = true;
            SettingsButtonActivated = true;

            if (materiScene == true) 
            {
                StartCoroutine(Animation(MateriNavbar, materiEndPosition, materiStartPosition));
                materiScene = false;
            }

            if (soalScene == true)
            {
                StartCoroutine(Animation(SoalNavbar, soalEndPosition, soalStartPosition));
                soalScene = false;
            }

            if (settingsScene == true)
            {
                StartCoroutine(Animation(SettingsNavbar, settingsEndPosition, settingsStartPosition));
                settingsScene = false;
            }
        }
    }

    public void materiSceneEnabled()
    {
        if (MateriButtonActivated == true && pressAble == true)
        {
            soundScript.buttonClickSound.Play();
            MainUI.SetActive(false);
            MateriUI.SetActive(true);
            SoalUI.SetActive(false);
            SettingsUI.SetActive(false);
            MateriButtonActivated = false;
            materiScene = true;
            StartCoroutine(Animation(MateriNavbar, materiStartPosition, materiEndPosition));
            StartCoroutine(Animation(Camera, cameraPosition, materiPosition));
            MainButtonActivated = true;
            SoalButtonActivated = true;
            SettingsButtonActivated = true;

            if (mainMenuScene == true)
            {
                StartCoroutine(Animation(MainMenuNavbar, mainMenuEndPosition, mainMenuStartPosition));
                mainMenuScene = false;
            }

            if (soalScene == true)
            {
                StartCoroutine(Animation(SoalNavbar, soalEndPosition, soalStartPosition));
                soalScene = false;
            }

            if (settingsScene == true)
            {
                StartCoroutine(Animation(SettingsNavbar, settingsEndPosition, settingsStartPosition));
                settingsScene = false;
            }
        }
    }

    public void soalSceneEnabled()
    {
        if (SoalButtonActivated == true && pressAble == true)
        {
            soundScript.buttonClickSound.Play();
            MainUI.SetActive(false);
            MateriUI.SetActive(false);
            SoalUI.SetActive(true);
            SettingsUI.SetActive(false);
            SoalButtonActivated = false;
            soalScene = true;
            StartCoroutine(Animation(SoalNavbar, soalStartPosition, soalEndPosition));
            StartCoroutine(Animation(Camera, cameraPosition, soalPosition));
            MainButtonActivated = true;
            MateriButtonActivated = true;
            SettingsButtonActivated = true;

            if (mainMenuScene == true)
            {
                StartCoroutine(Animation(MainMenuNavbar, mainMenuEndPosition, mainMenuStartPosition));
                mainMenuScene = false;
            }

            if (materiScene == true)
            {
                StartCoroutine(Animation(MateriNavbar, materiEndPosition, materiStartPosition));
                materiScene = false;
            }

            if (settingsScene == true)
            {
                StartCoroutine(Animation(SettingsNavbar, settingsEndPosition, settingsStartPosition));
                settingsScene = false;
            }
        }
    }

    public void settingsSceneEnabled()
    {
        if (SettingsButtonActivated == true && pressAble == true)
        {
            soundScript.buttonClickSound.Play();
            MainUI.SetActive(false);
            MateriUI.SetActive(false);
            SoalUI.SetActive(false);
            Invoke("SettingsUILoad", 0.15f);
            SettingsButtonActivated = false;
            settingsScene = true;
            StartCoroutine(Animation(SettingsNavbar, settingsStartPosition, settingsEndPosition));
            StartCoroutine(Animation(Camera, cameraPosition, settingsPosition));
            MainButtonActivated = true;
            MateriButtonActivated = true;
            SoalButtonActivated = true;

            if (mainMenuScene == true)
            {
                StartCoroutine(Animation(MainMenuNavbar, mainMenuEndPosition, mainMenuStartPosition));
                mainMenuScene = false;
            }

            if (materiScene == true)
            {
                StartCoroutine(Animation(MateriNavbar, materiEndPosition, materiStartPosition));
                materiScene = false;
            }

            if (soalScene == true)
            {
                StartCoroutine(Animation(SoalNavbar, soalEndPosition, soalStartPosition));
                soalScene = false;
            }
        }
    }

    public void SoalTambah()
    {
        StartCoroutine(Animation(Camera, cameraPosition, soalTambahPosition));
    }

    public void SettingsUILoad()
    {
        SettingsUI.SetActive(true);
    }

    IEnumerator Animation(GameObject navbar, Vector3 start, Vector3 end)
    {
        pressAble = false;
        elapsedTime = 0f;
        float percentageComplete = 0f;

        while (percentageComplete < 1f)
        {
            elapsedTime += Time.deltaTime;
            percentageComplete = elapsedTime / duration;

            navbar.transform.localPosition = Vector3.Lerp(start, end, curve.Evaluate(percentageComplete));
            yield return null;
        }

        navbar.transform.localPosition = end;
        pressAble = true;
    }
}
