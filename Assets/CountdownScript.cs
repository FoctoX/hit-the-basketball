using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CountdownScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite three;
    [SerializeField] private Sprite two;
    [SerializeField] private Sprite one;
    [SerializeField] private Sprite mulai;
    public bool startGameSwitch = false;
    public GameObject GameplayUI;
    public GameObject pauseUI;

    public GameObject countdownChildren;

    public BaksetballScript baksetballScript;
    public GameControllerScript gameControllerScript;
    public gameplayScript gameplayScript;
    public TutorialScript tutorialScript;
    public SoundScript soundScript;
    
    private void Awake()
    {
        baksetballScript = GameObject.FindGameObjectWithTag("BasketballTag").GetComponent<BaksetballScript>();
        gameControllerScript = GameObject.FindGameObjectWithTag("GameControllerTag").GetComponent<GameControllerScript>();
        gameplayScript = GameObject.FindGameObjectWithTag("GameplayTag").GetComponent<gameplayScript>();
        tutorialScript = GameObject.FindGameObjectWithTag("GameplayTag").GetComponent<TutorialScript>();
        spriteRenderer = countdownChildren.GetComponent<SpriteRenderer>();
        soundScript = GameObject.FindGameObjectWithTag("VolumeTag").GetComponent<SoundScript>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Countdown()
    {
        countdownChildren.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        startGameSwitch = false;
        spriteRenderer.enabled = true;
        spriteRenderer.sprite = three;
        yield return new WaitForSeconds(1.5f);
        spriteRenderer.sprite = three;
        yield return new WaitForSeconds(1);
        soundScript.countdownStart.Play();
        spriteRenderer.sprite = two;
        yield return new WaitForSeconds(1);
        soundScript.countdownStart.Play();
        spriteRenderer.sprite = one;
        yield return new WaitForSeconds(1);
        startGameSwitch = true;
        soundScript.countdownEnd.Play();
        spriteRenderer.sprite = mulai;
        gameControllerScript.StartGameObjectsWithCondition();
        yield return new WaitForSeconds(1);
        soundScript.playBGM.Play();
        spriteRenderer.enabled = false;
        GameplayUI.SetActive(true);
        gameplayScript.HoleStart();
        pauseUI.SetActive(true);
        gameObject.SetActive(false);
        countdownChildren.SetActive(false);
        yield return null;
    }

    public void CountdownStart()
    {
        StartCoroutine(Countdown());
    }
}
