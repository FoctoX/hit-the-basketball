using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LevelSelectorScript : MonoBehaviour
{
    public BaksetballScript[] gameObjectsWithScript;
    public BaksetballScript baksetballScript;

    public GameObject mainUI;
    public GameObject countdownManager;
    public GameObject levelSelectorUI;
    public GameObject mainMenuUI;
    public GameObject Camera;

    Vector3 levelSelectorPosition = new Vector3(540, 2880, -1);
    Vector3 mainMenuPosition = new Vector3(540, 960, -1);

    public SpriteRenderer level1Renderer;
    public SpriteRenderer level2Renderer;
    public SpriteRenderer level3Renderer;
    public SpriteRenderer level4Renderer;
    public SpriteRenderer level5Renderer;
    public SpriteRenderer level6Renderer;

    public Sprite level1Sprite;
    public Sprite level2Sprite;
    public Sprite level3Sprite;
    public Sprite level4Sprite;
    public Sprite level5Sprite;
    public Sprite level6Sprite;

    public GameObject level1Button;
    public GameObject level2Button;
    public GameObject level3Button;
    public GameObject level4Button;
    public GameObject level5Button;
    public GameObject level6Button;

    public bool level1Complete = false;
    public bool level2Complete = false;
    public bool level3Complete = false;
    public bool level4Complete = false;
    public bool level5Complete = false;
    public bool level6Complete = false;

    public int levelProgress = 0;
    public int levelPlayed;

    public GameProgress gameProgress;

    public MainScript mainScript;
    public gameplayScript gameplayScript;
    public MateriGameScript materiGameScript;
    public SoalGameScript soalGameScript;
    public Transition transition;
    public LogicManager logicManager;
    private void Awake()
    {
        gameProgress.playerProgress = levelProgress;
        level1Renderer = GameObject.FindGameObjectWithTag("Level1Tag").GetComponent<SpriteRenderer>();
        level2Renderer = GameObject.FindGameObjectWithTag("Level2Tag").GetComponent<SpriteRenderer>();
        level3Renderer = GameObject.FindGameObjectWithTag("Level3Tag").GetComponent<SpriteRenderer>();
        level4Renderer = GameObject.FindGameObjectWithTag("Level4Tag").GetComponent<SpriteRenderer>();
        level5Renderer = GameObject.FindGameObjectWithTag("Level5Tag").GetComponent<SpriteRenderer>();
        level6Renderer = GameObject.FindGameObjectWithTag("Level6Tag").GetComponent<SpriteRenderer>();
        baksetballScript = GameObject.FindGameObjectWithTag("BasketballTag").GetComponent<BaksetballScript>();
        mainScript = GameObject.FindGameObjectWithTag("MainMenuTag").GetComponent<MainScript>();
        gameplayScript = GameObject.FindGameObjectWithTag("GameplayTag").GetComponent<gameplayScript>();
        materiGameScript = GameObject.FindGameObjectWithTag("MateriGameTag").GetComponent<MateriGameScript>();
        soalGameScript = GameObject.FindGameObjectWithTag("SoalGameTag").GetComponent<SoalGameScript>();
        transition = GameObject.FindGameObjectWithTag("TransitionTag").GetComponent<Transition>();
        logicManager = GameObject.FindGameObjectWithTag("LogicTag").GetComponent<LogicManager>();
        gameObjectsWithScript = FindObjectsOfType<BaksetballScript>();
    }
    // Start is called before the first frame update
    void Start()
    {
        gameProgress = SaveAndLoadScript.LoadGame();
        levelProgress = gameProgress.playerProgress;
    }

    // Update is called once per frame
    void Update()
    {
        gameProgress.playerProgress = levelProgress;
        SaveAndLoadScript.SaveGame(gameProgress);

        LevelUpByProgress();
        gameProgress.playerProgress = levelProgress;
    }

    public void LevelSelectorExit()
    {
        if (logicManager.pressAble)
        {
            transition.AnimationFunction();
            Invoke("CameraExitPosition", 0.5f);
        }
    }

    public void CameraExitPosition()
    {
        Camera.transform.position = mainMenuPosition;
        levelSelectorUI.SetActive(false);
        mainMenuUI.SetActive(true);
        mainUI.SetActive(true);
    }

    public void LevelUpByProgress()
    {
        if (levelProgress >= 1)
        {
            level2Renderer.sprite = level2Sprite;
            level2Button.SetActive(true);
        }
        if (levelProgress >= 2)
        {
            level3Renderer.sprite = level3Sprite;
            level3Button.SetActive(true);
        }
        if (levelProgress >= 3)
        {
            level4Renderer.sprite = level4Sprite;
            level4Button.SetActive(true);
        }
        if (levelProgress >= 4)
        {
            level5Renderer.sprite = level5Sprite;
            level5Button.SetActive(true);
        }
        if (levelProgress >= 5)
        {
            level6Renderer.sprite = level6Sprite;
            level6Button.SetActive(true);
        }
    }

    public void Level1Enter()
    {
        if (logicManager.pressAble)
        {
            levelPlayed = 1;
            countdownManager.SetActive(true);
            materiGameScript.materiCount = 0;
            soalGameScript.soalLife = 3;
            soalGameScript.soalPoint = 0;
            materiGameScript.materiTarget = 3;
            soalGameScript.soalTarget = 3;
            mainScript.playGame();
            foreach (var gameObj in gameObjectsWithScript)
            {
                gameObj.showDuration = 3f;
                gameObj.materiChance = 0.1f;
                gameObj.duration = 0.5f;
                gameObj.firstChance = 3f;
                gameObj.secondChance = 8f;
            }
            gameplayScript.gameplaySwitch = true;
        }
    }

    public void Level2Enter()
    {
        if (logicManager.pressAble)
        {
            levelPlayed = 2;
            countdownManager.SetActive(true);
            materiGameScript.materiCount = 0;
            soalGameScript.soalLife = 3;
            soalGameScript.soalPoint = 0;
            materiGameScript.materiTarget = 4;
            soalGameScript.soalTarget = 4;
            mainScript.playGame();
            foreach (var gameObj in gameObjectsWithScript)
            {
                gameObj.showDuration = 2.5f;
                gameObj.materiChance = 0.1f;
                gameObj.duration = 0.5f;
                gameObj.firstChance = 2f;
                gameObj.secondChance = 6f;
            }
            gameplayScript.gameplaySwitch = true;
        }

    }

    public void Level3Enter()
    {
        if (logicManager.pressAble)
        {
            levelPlayed = 3;
            countdownManager.SetActive(true);
            materiGameScript.materiCount = 0;
            soalGameScript.soalLife = 3;
            soalGameScript.soalPoint = 0;
            materiGameScript.materiTarget = 3;
            soalGameScript.soalTarget = 3;
            mainScript.playGame();
            foreach (var gameObj in gameObjectsWithScript)
            {
                gameObj.showDuration = 2f;
                gameObj.materiChance = 0.05f;
                gameObj.duration = 0.4f;
                gameObj.firstChance = 2f;
                gameObj.secondChance = 4f;
            }
            gameplayScript.gameplaySwitch = true;
        }
    }

    public void Level4Enter()
    {
        if (logicManager.pressAble)
        {
            levelPlayed = 4;
            countdownManager.SetActive(true);
            materiGameScript.materiCount = 0;
            soalGameScript.soalLife = 3;
            soalGameScript.soalPoint = 0;
            materiGameScript.materiTarget = 5;
            soalGameScript.soalTarget = 5;
            mainScript.playGame();
            foreach (var gameObj in gameObjectsWithScript)
            {
                gameObj.showDuration = 1.5f;
                gameObj.materiChance = 0.05f;
                gameObj.duration = 0.4f;
                gameObj.firstChance = 1f;
                gameObj.secondChance = 4f;
            }
            gameplayScript.gameplaySwitch = true;
        }
    }

    public void Level5Enter()
    {
        if (logicManager.pressAble)
        {
            levelPlayed = 5;
            countdownManager.SetActive(true);
            materiGameScript.materiCount = 0;
            soalGameScript.soalLife = 3;
            soalGameScript.soalPoint = 0;
            materiGameScript.materiTarget = 3;
            soalGameScript.soalTarget = 3;
            mainScript.playGame();
            foreach (var gameObj in gameObjectsWithScript)
            {
                gameObj.showDuration = 1f;
                gameObj.materiChance = 0.05f;
                gameObj.duration = 0.25f;
                gameObj.firstChance = 1f;
                gameObj.secondChance = 3f;
            }
            gameplayScript.gameplaySwitch = true;
        }
    }

    public void Level6Enter()
    {
        if (logicManager.pressAble)
        {
            levelPlayed = 6;
            countdownManager.SetActive(true);
            materiGameScript.materiCount = 0;
            soalGameScript.soalLife = 3;
            soalGameScript.soalPoint = 0;
            materiGameScript.materiTarget = 7;
            soalGameScript.soalTarget = 5;
            mainScript.playGame();
            foreach (var gameObj in gameObjectsWithScript)
            {
                gameObj.showDuration = 1f;
                gameObj.materiChance = 0.05f;
                gameObj.duration = 0.25f;
                gameObj.firstChance = 1f;
                gameObj.secondChance = 3f;
            }
            gameplayScript.gameplaySwitch = true;
        }
    }

    public void Level1Complete()
    {
        if (levelProgress == 0 && levelPlayed == 1)
        {
            levelProgress = 1;
            level1Complete = true;
            level2Renderer.sprite = level2Sprite;
            level2Button.SetActive(true);
        }
    }

    public void Level2Complete()
    {
        if (levelProgress == 1 && levelPlayed == 2)
        {
            levelProgress = 2;
            level2Complete = true;
            level3Renderer.sprite = level3Sprite;
            level3Button.SetActive(true);
        }
    }

    public void Level3Complete()
{
        if (levelProgress == 2 && levelPlayed == 3)
        {
        levelProgress = 3;
        level3Complete = true;
        level4Renderer.sprite = level4Sprite;
        level4Button.SetActive(true);
    }
}

    public void Level4Complete()
    {
        if (levelProgress == 3 && levelPlayed == 4)
        {
            levelProgress = 4;
            level4Complete = true;
            level5Renderer.sprite = level5Sprite;
            level5Button.SetActive(true);
        }
    }

    public void Level5Complete()
    {
        if (levelProgress == 4 && levelPlayed == 5)
        {
            levelProgress = 5;
            level5Complete = true;
            level6Renderer.sprite = level6Sprite;
            level6Button.SetActive(true);
        }
    }

    public void Level6Complete()
    {
        if (levelProgress == 5 && levelPlayed == 6)
        {
            levelProgress = 6;
            level6Complete = true;
        }
    }
}

