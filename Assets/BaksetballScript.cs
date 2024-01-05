using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaksetballScript : MonoBehaviour
{
    private List<BaksetballScript> hitableObjects = new List<BaksetballScript>();

    Vector3 startPosition = new Vector3(0, -200, 0);
    Vector3 endPosition = Vector3.zero;

    Vector3 startScale = new Vector3(100, 100, 100);
    Vector3 endScale = new Vector3(90, 90, 90);

    Vector3 materiStartScale = new Vector3(100, 100, 100);
    Vector3 materiEndScale = new Vector3(110, 110, 110);

    public float duration;
    public float showDuration;
    public float materiChance;
    public float firstChance;
    public float secondChance;
    float elapsed;

    [SerializeField] private AnimationCurve curve;

    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite ballHit;
    [SerializeField] private Sprite ballNormal;
    [SerializeField] private Sprite ballMateri;
    [SerializeField] private Sprite none;

    private int ballTypes;

    bool isActive = true;
    bool hitable = true;
    bool ballLoop = true;
    public MainScript mainMenuScript;
    public MateriGameScript materiGameScript;
    public gameplayScript gameplayScript;
    public PauseScript pauseScript;
    public CountdownScript countdownScript;
    public SoundScript soundScript;
    public TutorialScript tutorialScript;

    public GameObject materi;
    public GameObject materiImage;
    public GameObject soal;
    public ParticleSystem hitParticle;
    public ParticleSystem materiParticle;
    private void Awake()
    {
        soundScript = GameObject.FindGameObjectWithTag("VolumeTag").GetComponent<SoundScript>();
        materiGameScript = GameObject.FindGameObjectWithTag("MateriGameTag").GetComponent<MateriGameScript>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameplayScript = GameObject.FindGameObjectWithTag("GameplayTag").GetComponent<gameplayScript>();
        tutorialScript = GameObject.FindGameObjectWithTag("GameplayTag").GetComponent<TutorialScript>();
        countdownScript = GameObject.FindGameObjectWithTag("CountdownTag").GetComponent<CountdownScript>();
        pauseScript = GameObject.FindGameObjectWithTag("PauseTag").GetComponent<PauseScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

                if (hit.collider != null)
                {
                    BaksetballScript script = hit.collider.GetComponent<BaksetballScript>();
                    if (script != null)
                    {
                        script.BallSmashed();
                    }
                }
            }
        }

        if (pauseScript.pauseSwitch == true || materiGameScript.materiPause == true || tutorialScript.tutorialPause)
        {
            Time.timeScale = 0;
        }

        if (pauseScript.pauseSwitch == false && materiGameScript.materiPause == false && !tutorialScript.tutorialPause)
        {
            Time.timeScale = 1;
        }
    }

    public void BackToStart()
    {
        transform.localPosition = startPosition;
    }

    IEnumerator BallMove()
    {
        ballLoop = true;
        yield return new WaitForSeconds(Random.Range(firstChance, secondChance));
        while (ballLoop && materiGameScript.materiCount < materiGameScript.materiTarget && gameplayScript.gameplaySwitch == true)
        {
            EnemyType();
            float percentage = 0;
            elapsed = 0;
            soundScript.showBallSound.Play();
            while (percentage <= 1f)
            {
                elapsed += Time.deltaTime;
                percentage = elapsed / duration;

                transform.localPosition = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(percentage));

                yield return null;
            }

            hitable = true;
            yield return new WaitForSeconds(showDuration);
            hitable = false;

            elapsed = 0;
            percentage = 0;
            soundScript.hideBallSound.Play();
            while (percentage <= 1f)
            {
                elapsed += Time.deltaTime;
                percentage = elapsed / duration;

                transform.localPosition = Vector3.Lerp(endPosition, startPosition, curve.Evaluate(percentage));

                yield return null;
            }

            if (materiGameScript.materiCount >= 1 && materiGameScript.materiCount < materiGameScript.materiTarget)
            {
                materiGameScript.materiCount = materiGameScript.materiCount - 1;
                soundScript.materiPointMinusSound.Play();
            }
        }
    }

    IEnumerator Ballhit()
    {
        transform.localScale = startScale;
        float percentage = 0;
        elapsed = 0;
        while (percentage <= 1f)
        {
            elapsed += Time.deltaTime;
            percentage = elapsed / 0.1f;

            transform.localScale = Vector3.Lerp(startScale, endScale, curve.Evaluate(percentage));

            yield return null;
        }

        transform.localScale = endScale;

        elapsed = 0;
        percentage = 0;
        while (percentage <= 1f)
        {
            elapsed += Time.deltaTime;
            percentage = elapsed / 0.4f;

            transform.localScale = Vector3.Lerp(endScale, startScale, curve.Evaluate(percentage));

            yield return null;
        }

        transform.localScale = startScale;

        if (ballLoop && materiGameScript.materiCount < materiGameScript.materiTarget && gameplayScript.gameplaySwitch == true)
        {
            StartCoroutine(BallFall());
        }
        yield return null;
    }

    IEnumerator MateriCollect()
    {
        transform.localScale = startScale;
        float percentage = 0;
        elapsed = 0;
        while (percentage <= 1f)
        {
            elapsed += Time.deltaTime;
            percentage = elapsed / duration;

            materiImage.transform.localScale = Vector3.Lerp(materiStartScale, materiEndScale, percentage);

            yield return null;
        }

        materiImage.transform.localScale = materiEndScale;

        elapsed = 0;
        percentage = 0;
        while (percentage <= 1f)
        {
            elapsed += Time.deltaTime;
            percentage = elapsed / duration;

            materiImage.transform.localScale = Vector3.Lerp(materiEndScale, materiStartScale, percentage);

            yield return null;
        }

        materiImage.transform.localScale = materiStartScale;
    }

    IEnumerator BallFall()
    {
        ballLoop = false;
        elapsed = 0;
        float percentage = 0;
        yield return new WaitForSeconds(1f);
        while (percentage <= 1f)
        {
            elapsed += Time.deltaTime;
            percentage = elapsed / duration;

            transform.localPosition = Vector3.Lerp(endPosition, startPosition, curve.Evaluate(percentage));
            yield return null;
        }
        if (materiGameScript.materiCount < materiGameScript.materiTarget && gameplayScript.gameplaySwitch == true)
        {
            StartCoroutine(BallMove());
        }
    }

    IEnumerator SoalAnimation(Vector3 start, Vector3 end)
    {
        float percentage = 0;
        elapsed = 0;
        while (percentage > 1f)
        {
            elapsed += Time.deltaTime;
            percentage = elapsed / duration;

            soal.transform.localPosition = Vector3.Lerp(start, end, curve.Evaluate(percentage));

            yield return null;
        }
        soal.transform.localPosition = end;
    }

    public void startGame()
    {
        StartCoroutine(BallMove());
    }

    void stopCoroutine()
    {
        StopAllCoroutines();
    }
    public void EnemyType()
    {
        float random = Random.Range(0f, 1f);
        if (random < materiChance)
        {
            ballTypes = 1;
            spriteRenderer.sprite = ballMateri;
        }
        else
        {
            ballTypes = 2;
            spriteRenderer.sprite = ballNormal;
        }
    }

    private void BallSmashed()
    {
        if (hitable && !materiGameScript.materiPause && !pauseScript.pauseSwitch && !materiGameScript.materiMove)
        {
            StopAllCoroutines();
            hitable = false;
            if (ballTypes == 1)
            {
                materiGameScript.StopAllCoroutines();
                materiGameScript.materiCount = materiGameScript.materiCount + 1;
                spriteRenderer.sprite = none;
                materiParticle.transform.position = transform.position;
                materiParticle.Play();
                soundScript.materiShow.Play();
                StartCoroutine(MateriCollect());
                StartCoroutine(Ballhit());
                materiGameScript.MateriShow();
            }
            else if (ballTypes == 2)
            { 
                hitParticle.transform.position = transform.position;
                hitParticle.Play();
                StartCoroutine(Ballhit());
                soundScript.ballHitSound.Play();
                spriteRenderer.sprite = ballHit;
            }
        }
    }
}
