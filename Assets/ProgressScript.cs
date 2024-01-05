using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressScript : MonoBehaviour
{
    public SpriteRenderer headerMateriSejarah;
    public SpriteRenderer headerMateriTeknik;
    public SpriteRenderer headerMateriAturan;
    public SpriteRenderer headerMateriPassing;
    public SpriteRenderer headerMateriDribble;
    public SpriteRenderer headerMateriShooting;
    public SpriteRenderer headerMateriLainnya;

    public GameObject materiSejarahUI;
    public GameObject materiTeknikUI;
    public GameObject materiAturanUI;
    public GameObject materiPassingUI;
    public GameObject materiDribbleUI;
    public GameObject materiShootingUI;
    public GameObject materiLainnyaUI;

    public GameObject headerSoalSejarah;
    public GameObject headerSoalTeknik;
    public GameObject headerSoalAturan;
    public SpriteRenderer headerSoalPassing;
    public SpriteRenderer headerSoalDribble;
    public SpriteRenderer headerSoalShooting;
    public SpriteRenderer headerSoalLainnya;

    public GameObject lockSoalSejarah;
    public GameObject lockSoalTeknik;
    public GameObject lockSoalAturan;

    public GameObject soalSejarahUI;
    public GameObject soalTeknikUI;
    public GameObject soalAturanUI;
    public GameObject soalPassingUI;
    public GameObject soalDribbleUI;
    public GameObject soalShootingUI;
    public GameObject soalLainnyaUI;

    public Sprite textMateriSejarah;
    public Sprite textMateriTeknik;
    public Sprite textMateriAturan;
    public Sprite textMateriPassing;
    public Sprite textMateriDribble;
    public Sprite textMateriShooting;
    public Sprite textMateriLainnya;

    public Sprite textSoalPassing;
    public Sprite textSoalDribble;
    public Sprite textSoalShooting;
    public Sprite textSoalLainnya;

    public Image progressBar;

    public Sprite zeroBar;
    public Sprite oneBar;
    public Sprite twoBar;
    public Sprite threeBar;

    public LevelSelectorScript levelSelectorScript;

    private void Awake()
    {
        levelSelectorScript = GameObject.FindGameObjectWithTag("LevelSelectorTag").GetComponent<LevelSelectorScript>();

        headerMateriSejarah = GameObject.FindGameObjectWithTag("UpperMateriSejarah").GetComponent<SpriteRenderer>();
        headerMateriTeknik = GameObject.FindGameObjectWithTag("UpperMateriTeknik").GetComponent<SpriteRenderer>();
        headerMateriAturan = GameObject.FindGameObjectWithTag("UpperMateriAturan").GetComponent<SpriteRenderer>();
        headerMateriPassing = GameObject.FindGameObjectWithTag("UpperMateriPassing").GetComponent<SpriteRenderer>();
        headerMateriDribble = GameObject.FindGameObjectWithTag("UpperMateriDribble").GetComponent<SpriteRenderer>();
        headerMateriShooting = GameObject.FindGameObjectWithTag("UpperMateriShooting").GetComponent<SpriteRenderer>();
        headerMateriLainnya = GameObject.FindGameObjectWithTag("UpperMateriLainnya").GetComponent<SpriteRenderer>();

        headerSoalPassing = GameObject.FindGameObjectWithTag("UpperSoalPassing").GetComponent<SpriteRenderer>();
        headerSoalDribble = GameObject.FindGameObjectWithTag("UpperSoalDribble").GetComponent<SpriteRenderer>();
        headerSoalShooting = GameObject.FindGameObjectWithTag("UpperSoalShooting").GetComponent<SpriteRenderer>();
        headerSoalLainnya = GameObject.FindGameObjectWithTag("UpperSoalLainnya").GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Progress();
    }

    [ContextMenu("ProgressUp")]
    public void ProgressPlus()
    {
        levelSelectorScript.levelProgress = levelSelectorScript.levelProgress + 1;
    }

    [ContextMenu("ProgressReset")]
    public void ResetGame()
    {
        SaveAndLoadScript.ResetGameData();
    }

    public void Progress()
    {
        if (levelSelectorScript.levelProgress >= 1)
        {
            headerMateriSejarah.sprite = textMateriSejarah;
            headerSoalSejarah.SetActive(true);
            materiSejarahUI.SetActive(true);
            soalSejarahUI.SetActive(true);
            lockSoalSejarah.SetActive(false);
            levelSelectorScript.level1Complete = true;
        }
        if (levelSelectorScript.levelProgress >= 2)
        {
            headerMateriTeknik.sprite = textMateriTeknik;
            headerSoalTeknik.SetActive(true);
            materiTeknikUI.SetActive(true);
            soalTeknikUI.SetActive(true);
            headerMateriPassing.sprite = textMateriPassing;
            headerSoalPassing.sprite = textSoalPassing;
            materiPassingUI.SetActive(true);
            soalPassingUI.SetActive(true);
            lockSoalTeknik.SetActive(false);
            levelSelectorScript.level2Complete = true;
        }
        if (levelSelectorScript.levelProgress >= 3)
        {
            headerMateriDribble.sprite = textMateriDribble;
            headerSoalDribble.sprite = textSoalDribble;
            materiDribbleUI.SetActive(true);
            soalDribbleUI.SetActive(true);
            levelSelectorScript.level3Complete = true;
        }
        if (levelSelectorScript.levelProgress >= 4)
        {
            headerMateriShooting.sprite = textMateriShooting;
            headerSoalShooting.sprite = textSoalShooting;
            materiShootingUI.SetActive(true);
            soalShootingUI.SetActive(true);
            levelSelectorScript.level4Complete = true;
        }
        if (levelSelectorScript.levelProgress >= 5)
        {
            headerMateriLainnya.sprite = textMateriLainnya;
            headerSoalLainnya.sprite = textSoalLainnya;
            materiLainnyaUI.SetActive(true);
            soalLainnyaUI.SetActive(true);
            levelSelectorScript.level5Complete = true;
        }
        if (levelSelectorScript.levelProgress >= 6)
        {
            headerMateriAturan.sprite = textMateriAturan;
            headerSoalAturan.SetActive(true);
            materiAturanUI.SetActive(true);
            soalAturanUI.SetActive(true);
            lockSoalAturan.SetActive(false);
            levelSelectorScript.level6Complete = true;
        }

        switch (levelSelectorScript.levelProgress)
        {
            case 0:
                progressBar.sprite = zeroBar;
                break;
            case 1:
                progressBar.sprite = oneBar;
                break;
            case 2:
                progressBar.sprite = oneBar;
                break;
            case 3:
                progressBar.sprite = oneBar;
                break;
            case 4:
                progressBar.sprite = oneBar;
                break;
            case 5:
                progressBar.sprite = twoBar;
                break;
            case 6:
                progressBar.sprite = threeBar;
                break;
        }
    }
}
