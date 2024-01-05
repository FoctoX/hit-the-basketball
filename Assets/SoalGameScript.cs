using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoalGameScript : MonoBehaviour
{
    public LevelSelectorScript levelSelectorScript;
    public MateriGameScript materiGameScript;
    public RedBackgroundScript redBackgroundScript;
    public gameplayScript gameplayScript;
    public SoalScript soalScript;
    public SoundScript soundScript;

    [SerializeField]
    private AnimationCurve SoalAnimationCurve;

    [SerializeField]
    private AnimationCurve BallBossIdleCurve;

    public GameObject gameplayUI;
    public GameObject soalMainUI;
    public Text soalText;
    public GameObject soalTextUI;
    public Text button1Text;
    public GameObject button1UI;
    public Text button2Text;
    public GameObject button2UI;
    public Text button3Text;
    public GameObject button3UI;

    public GameObject Camera;
    public GameObject pauseUI;
    public GameObject bossBall;
    public GameObject soalSelectorBox;
    public GameObject allHeart;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject pauseButton;

    public Vector3 soalBoxStartPosition;
    public Vector3 soalBoxEndPosition;
    public Vector3 ballBossStartPosition;
    public Vector3 ballBossEndPosition;
    public Vector3 ballBossEndDynamicPosition;
    public Vector3 ballBossIdleEndPosition;
    public Vector3 heartStartPosition;
    public Vector3 heartEndPosition;

    public Animator ballBossIdle;

    public int soalLife;
    public int soalPoint;
    public int soalTarget;

    public ParticleSystem heartBroke;
    public ParticleSystem particleBoss;

    private void Awake()
    {
        levelSelectorScript = GameObject.FindGameObjectWithTag("LevelSelectorTag").GetComponent<LevelSelectorScript>();
        materiGameScript = GameObject.FindGameObjectWithTag("MateriGameTag").GetComponent<MateriGameScript>();
        redBackgroundScript = GameObject.FindGameObjectWithTag("RedBackgroundTag").GetComponent<RedBackgroundScript>();
        gameplayScript = GameObject.FindGameObjectWithTag("GameplayTag").GetComponent<gameplayScript>();
        soalScript = GameObject.FindGameObjectWithTag("SoalTag").GetComponent<SoalScript>();
        soundScript = GameObject.FindGameObjectWithTag("VolumeTag").GetComponent<SoundScript>();

        soalBoxStartPosition = new Vector3(0, -1230, 0);
        soalBoxEndPosition = new Vector3(0, -690, 0);
        ballBossStartPosition = new Vector3(0, -1600, 0);
        ballBossEndPosition = new Vector3(0, -350, 0);
        ballBossIdleEndPosition = new Vector3(0, -300, 0);
        heartStartPosition = new Vector3(0, -675, 0);
        heartEndPosition = new Vector3(0, 0, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SoalTextShow();
        JawabanText();
        LifeHeart();

        ballBossEndDynamicPosition = bossBall.transform.localPosition;
    }

    public void BackToStart()
    {
        particleBoss.Stop();
        soalSelectorBox.transform.localPosition = soalBoxStartPosition;
        bossBall.transform.localPosition = ballBossStartPosition;
        allHeart.transform.localPosition = heartStartPosition;
        soalMainUI.SetActive(false);
    }

    public void PlaySoalWithoutGameplay()
    {
        gameplayScript.gameplaySwitch = true;
        PlaySoal();
        soalScript.soalSoloPlayed = true;
        Invoke("PauseInvoke", 0.5f);
        soalLife = 3;
    }

    void PauseInvoke()
    {
        pauseUI.SetActive(true);
    }

    public void SoalClear()
    {
        if (soalPoint >= soalTarget)
        {
            StopSoal();
        }
    }

    public void SoalLose()
    {
        if (soalLife <= 0)
        {
            LoseSoal();
        }
    }

    public void SoalPlay()
    {
        if (materiGameScript.materiCount >= materiGameScript.materiTarget)
        {
            PlaySoal();
        }
    }

    public void WinPage()
    {
        gameplayScript.WinPageShow();
    }

    public void LosePage()
    {
        gameplayScript.LosePageShow();
    }

    public void PlaySoal()
    {
        soundScript.playBGM.Stop();
        soundScript.soalBGM.Play();
        gameplayUI.SetActive(false);
        gameplayScript.HoleEnd();
        StartCoroutine(AnimationSoal(soalSelectorBox, soalBoxStartPosition, soalBoxEndPosition, 2f));
        StartCoroutine(AnimationHeart(allHeart, heartStartPosition, heartEndPosition, 3f));
        StartCoroutine(AnimationBallBoss(bossBall, ballBossStartPosition, ballBossEndPosition, 4f, true));
        StartCoroutine(AnimationBallBossIdle(bossBall, ballBossEndPosition, ballBossIdleEndPosition, 5f));
        redBackgroundScript.FadeInOn();
    }

    public void StopSoal()
    {
        particleBoss.Stop();
        StopAllCoroutines();
        StartCoroutine(AnimationSoal(soalSelectorBox, soalBoxEndPosition, soalBoxStartPosition, 4f));
        StartCoroutine(AnimationHeart(allHeart, heartEndPosition, heartStartPosition, 3f));
        StartCoroutine(AnimationBallBoss(bossBall, ballBossEndDynamicPosition, ballBossStartPosition, 2f, false));
        redBackgroundScript.FadeOutOn();
        soalMainUI.SetActive(false);
        pauseButton.SetActive(false);
        Invoke("WinPage", 5f);
    }

    public void LoseSoal()
    {
        particleBoss.Stop();
        StopAllCoroutines();
        StartCoroutine(AnimationSoal(soalSelectorBox, soalBoxEndPosition, soalBoxStartPosition, 4f));
        StartCoroutine(AnimationHeart(allHeart, heartEndPosition, heartStartPosition, 3f));
        StartCoroutine(AnimationBallBoss(bossBall, ballBossEndDynamicPosition, ballBossStartPosition, 2f, false));
        soalMainUI.SetActive(false);
        pauseButton.SetActive(false);
        Invoke("LosePage", 5f);
    }

    IEnumerator AnimationSoal(GameObject navbar, Vector3 start, Vector3 end, float time)
    {
        yield return new WaitForSeconds(time);
        float duration = 1f;
        float elapsedTime = 0f;
        float percentageComplete = 0f;

        while (percentageComplete < 1f)
        {
            elapsedTime += Time.deltaTime;
            percentageComplete = elapsedTime / duration;

            navbar.transform.localPosition = Vector3.Lerp(start, end, SoalAnimationCurve.Evaluate(percentageComplete));
            yield return null;
        }

        navbar.transform.localPosition = end;
    }

    IEnumerator AnimationHeart(GameObject navbar, Vector3 start, Vector3 end, float time)
    {
        yield return new WaitForSeconds(time);
        float duration = 1f;
        float elapsedTime = 0f;
        float percentageComplete = 0f;

        while (percentageComplete < 1f)
        {
            elapsedTime += Time.deltaTime;
            percentageComplete = elapsedTime / duration;

            navbar.transform.localPosition = Vector3.Lerp(start, end, SoalAnimationCurve.Evaluate(percentageComplete));
            yield return null;
        }

        navbar.transform.localPosition = end;
    }

    IEnumerator AnimationBallBoss(GameObject navbar, Vector3 start, Vector3 end, float time, bool boolean)
    {
        yield return new WaitForSeconds(time);
        float duration = 1f;
        float elapsedTime = 0f;
        float percentageComplete = 0f;

        while (percentageComplete < 1f)
        {
            elapsedTime += Time.deltaTime;
            percentageComplete = elapsedTime / duration;

            navbar.transform.localPosition = Vector3.Lerp(start, end, SoalAnimationCurve.Evaluate(percentageComplete));
            yield return null;
        }

        if (boolean)
        {
            soalMainUI.SetActive(true);
            soundScript.soalShowSound.Play();
            particleBoss.Play();
        }


        navbar.transform.localPosition = end;
    }

    IEnumerator AnimationBallBossIdle(GameObject navbar, Vector3 start, Vector3 end, float time)
    {
        yield return new WaitForSeconds(time);
        while (true)
        {
            float duration = 2f;
            float elapsedTime = 0f;
            float percentageComplete = 0f;

            while (percentageComplete <= 1f)
            {
                elapsedTime += Time.deltaTime;
                percentageComplete = elapsedTime / duration;

                navbar.transform.localPosition = Vector3.Lerp(start, end, BallBossIdleCurve.Evaluate(percentageComplete));
                yield return null;
            }

            duration = 2f;
            elapsedTime = 0f;
            percentageComplete = 0f;

            while (percentageComplete <= 1f)
            {
                elapsedTime += Time.deltaTime;
                percentageComplete = elapsedTime / duration;

                navbar.transform.localPosition = Vector3.Lerp(end, start, BallBossIdleCurve.Evaluate(percentageComplete));
                yield return null;
            }
        }
    }

    public void LifeHeart()
    {
        switch (soalLife)
        {
            case 0:
                heart1.SetActive(false);
                heart2.SetActive(false);
                heart3.SetActive(false);
                break;
            case 1:
                heart1.SetActive(true);
                heart2.SetActive(false);
                heart3.SetActive(false);
                break;
            case 2:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(false);
                break;
            case 3:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                break;
        }
    }

    public void SoalMainUIOn()
    {
        if (gameplayScript.gameplaySwitch == true)
        {
            soalMainUI.SetActive(true);
            soundScript.soalShowSound.Play();
        }
    }

    public void SoalMainUIOff()
    {
        soalMainUI.SetActive(false);
    }

    public void SoalTextShow()
    {
        switch (levelSelectorScript.levelPlayed)
        {
            case 1:
                switch (soalPoint)
                {
                    case 0:
                        soalText.text = "Bagaimana cara mendapatkan skor dalam permainan bola basket?";
                        break;
                    case 1:
                        soalText.text = "Siapa pencipta permainan bola basket?";
                        break;
                    case 2:
                        soalText.text = "Apa penyebab permainan bola basket masuk ke Indonesia?";
                        break;
                }
                break;

            case 2:
                switch (soalPoint)
                {
                    case 0:
                        soalText.text = "Teknik passing bertujuan untuk?";
                        break;
                    case 1:
                        soalText.text = "Passing dimana bola sejajar dengan dada disebut?";
                        break;
                    case 2:
                        soalText.text = "Overhead pass dilakukukan dengan posisi bola berada di?";
                        break;
                    case 3:
                        soalText.text = "Passing dengan memantulkan bola disebut?";
                        break;
                }
                break;

            case 3:
                switch (soalPoint)
                {
                    case 0:
                        soalText.text = "Cara menggiring bola dalam permainan bola basket disebut?";
                        break;
                    case 1:
                        soalText.text = "Jenis dribble untuk mengecoh lawan adalah?";
                        break;
                    case 2:
                        soalText.text = "Dribble yang dengan pantulan bola yang tinggi adalah?";
                        break;
                }
                break;

            case 4:
                switch (soalPoint)
                {
                    case 0:
                        soalText.text = "Teknik memasukkan bola ke dalam ring disebut?";
                        break;
                    case 1:
                        soalText.text = "Teknik shooting paling mudah adalah?";
                        break;
                    case 2:
                        soalText.text = "Teknik shooting lay up dilakukan dengan?";
                        break;
                    case 3:
                        soalText.text = "Teknik shooting pada titik lompat tertinggi disebut?";
                        break;
                    case 4:
                        soalText.text = "Teknik shooting sambil memegang ring basket disebut?";
                        break;
                }
                break;

            case 5:
                switch (soalPoint)
                {
                    case 0:
                        soalText.text = "Teknik melakukan perputaran tubuh dengn tumpuan satu kaki disebut?";
                        break;
                    case 1:
                        soalText.text = "Fungsi teknik pivot adalah?";
                        break;
                    case 2:
                        soalText.text = "Teknik pemanfaatan bola yang gagal masuk ring disebut?";
                        break;
                }
                break;

            case 6:
                switch (soalPoint)
                {
                    case 0:
                        soalText.text = "Berapa jumlah pemain utama permainan bola basket?";
                        break;
                    case 1:
                        soalText.text = "Aturan 3 detik berlaku pada area?";
                        break;
                    case 2:
                        soalText.text = "Waktu maksimal untuk memainkan bola di daerah pertahanannya sendiri adalah?";
                        break;
                    case 3:
                        soalText.text = "Waktu maksimal untuk melakukan serangan adalah?";
                        break;
                    case 4:
                        soalText.text = "Berapa batas pelanggaran seorang pemain?";
                        break;
                    case 5:
                        soalText.text = "Apa yang terjadi jika seorang pemain melakukan dribble kemudian berhenti dan memegang bola dengan kedua tangannya?";
                        break;
                }
                break;
        }
    }

    public void JawabanText()
    {
        switch (levelSelectorScript.levelPlayed)
        {
            case 1:
                switch (soalPoint)
                {
                    case 0:
                        button1Text.text = "Menyentuh lawan";
                        button2Text.text = "Merebut bola dari lawan";
                        button3Text.text = "Memasukkan bola ke ring";
                        break;
                    case 1:
                        button1Text.text = "James Gordon";
                        button2Text.text = "James Naismith";
                        button3Text.text = "James Henry";
                        break;
                    case 2:
                        button1Text.text = "Dibawa oleh Belanda";
                        button2Text.text = "Eksodus warga China";
                        button3Text.text = "Perdagangan bangsa asing";
                        break;
                }
                break;

            case 2:
                switch (soalPoint)
                {
                    case 0:
                        button1Text.text = "Melempar bola ke ring";
                        button2Text.text = "Menggocek lawan";
                        button3Text.text = "Mengoper bola ke rekan tim";
                        break;
                    case 1:
                        button1Text.text = "Chest pass";
                        button2Text.text = "Body pass";
                        button3Text.text = "Front pass";
                        break;
                    case 2:
                        button1Text.text = "Sekitar kepala";
                        button2Text.text = "Di atas kepala";
                        button3Text.text = "Di samping kepala";
                        break;
                    case 3:
                        button1Text.text = "Bounce pass";
                        button2Text.text = "Hoop pass";
                        button3Text.text = "Back pass";
                        break;
                }
                break;

            case 3:
                switch (soalPoint)
                {
                    case 0:
                        button1Text.text = "Dribble";
                        button2Text.text = "Moving";
                        button3Text.text = "Pivot";
                        break;
                    case 1:
                        button1Text.text = "Dribble rendah";
                        button2Text.text = "Dribble cepat";
                        button3Text.text = "Dribble atas";
                        break;
                    case 2:
                        button1Text.text = "Dribble keras";
                        button2Text.text = "Dribble tinggi";
                        button3Text.text = "Dribble melambung";
                        break;
                }
                break;

            case 4:
                switch (soalPoint)
                {
                    case 0:
                        button1Text.text = "Entering";
                        button2Text.text = "Flying";
                        button3Text.text = "Shooting";
                        break;
                    case 1:
                        button1Text.text = "Set shoot";
                        button2Text.text = "Basic shoot";
                        button3Text.text = "Short shoot";
                        break;
                    case 2:
                        button1Text.text = "Satu tangan";
                        button2Text.text = "Dua tangan";
                        button3Text.text = "Sundulan kepala";
                        break;
                    case 3:
                        button1Text.text = "Jump shoot";
                        button2Text.text = "Let shoot";
                        button3Text.text = "Long shoot";
                        break;
                    case 4:
                        button1Text.text = "Hold shoot";
                        button2Text.text = "Slam dunk";
                        button3Text.text = "Super slam";
                        break;
                }
                break;

            case 5:
                switch (soalPoint)
                {
                    case 0:
                        button1Text.text = "Hold";
                        button2Text.text = "Crane";
                        button3Text.text = "Pivot";
                        break;
                    case 1:
                        button1Text.text = "Mengecoh lawan";
                        button2Text.text = "Merebut bola";
                        button3Text.text = "Mencetak skor";
                        break;
                    case 2:
                        button1Text.text = "Backdown";
                        button2Text.text = "Backball";
                        button3Text.text = "Rebound";
                        break;
                }
                break;

            case 6:
                switch (soalPoint)
                {
                    case 0:
                        button1Text.text = "Lima pemain";
                        button2Text.text = "Enam pemain";
                        button3Text.text = "Tujuh pemain";
                        break;
                    case 1:
                        button1Text.text = "Tengah lapangan";
                        button2Text.text = "Pertahanan lawan";
                        button3Text.text = "Di bawah ring";
                        break;
                    case 2:
                        button1Text.text = "Empat detik";
                        button2Text.text = "Enam detik";
                        button3Text.text = "Delapan detik";
                        break;
                    case 3:
                        button1Text.text = "24 detik";
                        button2Text.text = "32 detik";
                        button3Text.text = "1 menit";
                        break;
                    case 4:
                        button1Text.text = "2 kali";
                        button2Text.text = "3 kali";
                        button3Text.text = "4 kali";
                        break;
                    case 5:
                        button1Text.text = "Pemain tidak boleh men-dribble lagi";
                        button2Text.text = "Pemain didiskualifikasi";
                        button3Text.text = "Pemain diberikan sanksi";
                        break;
                }
                break;
        }
    }

    public void Button1()
    {
        switch (levelSelectorScript.levelPlayed)
        {
            case 1:
                switch (soalPoint)
                {
                    case 0:
                        FalseAnswer();
                        break;
                    case 1:
                        FalseAnswer();
                        break;
                    case 2:
                        FalseAnswer();
                        break;
                }
                break;

            case 2:
                switch (soalPoint)
                {
                    case 0:
                        FalseAnswer();
                        break;
                    case 1:
                        TrueAnswer();
                        break;
                    case 2:
                        FalseAnswer();
                        break;
                    case 3:
                        TrueAnswer();
                        break;
                }
                break;

            case 3:
                switch (soalPoint)
                {
                    case 0:
                        TrueAnswer();
                        break;
                    case 1:
                        TrueAnswer();
                        break;
                    case 2:
                        FalseAnswer();
                        break;
                }
                break;

            case 4:
                switch (soalPoint)
                {
                    case 0:
                        FalseAnswer();
                        break; 
                    case 1:
                        TrueAnswer();
                        break;
                    case 2:
                        TrueAnswer();
                        break;
                    case 3:
                        TrueAnswer();
                        break;
                    case 4:
                        FalseAnswer();
                        break;
                }
                break;

            case 5:
                switch (soalPoint)
                {
                    case 0:
                        FalseAnswer();
                        break;
                    case 1:
                        TrueAnswer();
                        break;
                    case 2:
                        FalseAnswer();
                        break;
                }
                break;

            case 6:
                switch (soalPoint)
                {
                    case 0:
                        TrueAnswer();
                        break;
                    case 1:
                        FalseAnswer();
                        break;
                    case 2:
                        FalseAnswer();
                        break;
                    case 3:
                        TrueAnswer();
                        break;
                    case 4:
                        FalseAnswer();
                        break;
                    case 5:
                        TrueAnswer();
                        break;
                }
                break;
        }
    }

    public void Button2()
    {
        switch (levelSelectorScript.levelPlayed)
        {
            case 1:
                switch (soalPoint)
                {
                    case 0:
                        FalseAnswer();
                        break;
                    case 1:
                        TrueAnswer();
                        break;
                    case 2:
                        TrueAnswer();
                        break;
                }
                break;

            case 2:
                switch (soalPoint)
                {
                    case 0:
                        FalseAnswer();
                        break;
                    case 1:
                        FalseAnswer();
                        break;
                    case 2:
                        TrueAnswer();
                        break;
                    case 3:
                        FalseAnswer();
                        break;
                }
                break;

            case 3:
                switch (soalPoint)
                {
                    case 0:
                        FalseAnswer();
                        break;
                    case 1:
                        FalseAnswer();
                        break;
                    case 2:
                        TrueAnswer();
                        break;
                }
                break;

            case 4:
                switch (soalPoint)
                {
                    case 0:
                        FalseAnswer();
                        break;
                    case 1:
                        FalseAnswer();
                        break;
                    case 2:
                        FalseAnswer();
                        break;
                    case 3:
                        FalseAnswer();
                        break;
                    case 4:
                        TrueAnswer();
                        break;
                }
                break;

            case 5:
                switch (soalPoint)
                {
                    case 0:
                        FalseAnswer();
                        break;
                    case 1:
                        FalseAnswer();
                        break;
                    case 2:
                        FalseAnswer();
                        break;
                }
                break;

            case 6:
                switch (soalPoint)
                {
                    case 0:
                        FalseAnswer();
                        break;
                    case 1:
                        TrueAnswer();
                        break;
                    case 2:
                        FalseAnswer();
                        break;
                    case 3:
                        FalseAnswer();
                        break;
                    case 4:
                        FalseAnswer();
                        break;
                    case 5:
                        FalseAnswer();
                        break;
                }
                break;
        }
    }

    public void Button3()
    {
        switch (levelSelectorScript.levelPlayed)
        {
            case 1:
                switch (soalPoint)
                {
                    case 0:
                        TrueAnswer();
                        break;
                    case 1:
                        FalseAnswer();
                        break;
                    case 2:
                        FalseAnswer();
                        break;
                }
                break;

            case 2:
                switch (soalPoint)
                {
                    case 0:
                        TrueAnswer();
                        break;
                    case 1:
                        FalseAnswer();
                        break;
                    case 2:
                        FalseAnswer();
                        break;
                    case 3:
                        FalseAnswer();
                        break;
                }
                break;

            case 3:
                switch (soalPoint)
                {
                    case 0:
                        FalseAnswer();
                        break;
                    case 1:
                        FalseAnswer();
                        break;
                    case 2:
                        FalseAnswer();
                        break;
                }
                break;

            case 4:
                switch (soalPoint)
                {
                    case 0:
                        TrueAnswer();
                        break;
                    case 1:
                        FalseAnswer();
                        break;
                    case 2:
                        FalseAnswer();
                        break;
                    case 3:
                        FalseAnswer();
                        break;
                    case 4:
                        FalseAnswer();
                        break;
                }
                break;

            case 5:
                switch (soalPoint)
                {
                    case 0:
                        TrueAnswer();
                        break;
                    case 1:
                        FalseAnswer();
                        break;
                    case 2:
                        TrueAnswer();
                        break;
                }
                break;

            case 6:
                switch (soalPoint)
                {
                    case 0:
                        FalseAnswer();
                        break;
                    case 1:
                        FalseAnswer();
                        break;
                    case 2:
                        TrueAnswer();
                        break;
                    case 3:
                        FalseAnswer();
                        break;
                    case 4:
                        TrueAnswer();
                        break;
                    case 5:
                        FalseAnswer();
                        break;
                }
                break;
        }
    }

    public void TrueAnswer()
    {
        soundScript.trueAnswerSound.Play();
        soalPoint = soalPoint + 1;
        SoalClear();
    }

    public void FalseAnswer()
    {
        switch (soalLife)
        {
            case 3:
                heartBroke.transform.position = heart3.transform.position;
                heartBroke.Play();
                break;
            case 2:
                heartBroke.transform.position = heart2.transform.position;
                heartBroke.Play();
                break;
            case 1:
                heartBroke.transform.position = heart1.transform.position;
                heartBroke.Play();
                break;
        }
        soundScript.wrongAnswerSound.Play();
        soalLife = soalLife - 1;
        SoalLose();

    }
}
