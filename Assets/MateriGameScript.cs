using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class MateriGameScript : MonoBehaviour
{
    public BaksetballScript ballScript;
    public CountdownScript countdownScript;
    public MainScript mainScript;
    public LevelSelectorScript levelSelectorScript;
    public gameplayScript gameplayScript;
    public SoalGameScript soalGameScript;
    public GameControllerScript gameControllerScript;
    public PauseScript pauseScript;
    public SoundScript soundScript;
    

    public Text materiGameIsi;
    public GameObject materiGameIsiUI;

    Vector3 startMateri = new Vector3(0, -1230, 0);
    Vector3 startMateriDynamic;
    Vector3 endMateri = new Vector3(0, -690, 0);

    [SerializeField] private AnimationCurve curve;

    public float duration = 0.5f;
    float elapsed;

    public bool materiUp;
    public bool materiPause = false;
    public int materiCount;
    public int materiTarget;

    bool isActive;
    public bool materiMove = false;
    private void Awake()
    {
        ballScript = GameObject.FindGameObjectWithTag("BasketballTag").GetComponent<BaksetballScript>();
        countdownScript = GameObject.FindGameObjectWithTag("CountdownTag").GetComponent<CountdownScript>();
        mainScript = GameObject.FindGameObjectWithTag("MainMenuTag").GetComponent<MainScript>();
        levelSelectorScript = GameObject.FindGameObjectWithTag("LevelSelectorTag").GetComponent<LevelSelectorScript>();
        gameplayScript = GameObject.FindGameObjectWithTag("GameplayTag").GetComponent<gameplayScript>();
        soalGameScript = GameObject.FindGameObjectWithTag("SoalGameTag").GetComponent<SoalGameScript>();
        gameControllerScript = GameObject.FindGameObjectWithTag("GameControllerTag").GetComponent<GameControllerScript>();
        pauseScript = GameObject.FindGameObjectWithTag("PauseTag").GetComponent<PauseScript>();
        soundScript = GameObject.FindGameObjectWithTag("VolumeTag").GetComponent<SoundScript>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MateriGameShow();

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
                if (hit.collider != null)
                {
                    MateriGameScript script = hit.collider.GetComponent<MateriGameScript>();
                    if (script != null)
                    {
                        script.MateriClick();
                    }
                }
            }
        }
        startMateriDynamic = transform.localPosition;
    }

    public void BackToStart()
    {
        materiGameIsiUI.SetActive(false);
        transform.localPosition = startMateri;
    }

    public void MateriGameShow()
    {
        switch (levelSelectorScript.levelPlayed)
        {
            case 1:
                switch (materiCount)
                {
                    case 1:
                        materiGameIsi.text = "Bola basket merupakan permainan yang berlangsung dengan cara mempertandingkan dua tim basket dan berebut bola untuk dimasukkan ke dalam ring lawan untuk mencetak skor.";
                        break;
                    case 2:
                        materiGameIsi.text = "James Naismith yang mencatatkan namanya dalam sejarah sebagai pencetus permainan bola basket ini.";
                        break;
                    case 3:
                        materiGameIsi.text = "Sejarah mencatat, pada tahun 1920, terjadi eksodus warga negara China ke negara-negara Asia Tenggara, salah satunya Indonesia.";
                        break;
                }
                break;

            case 2:
                switch (materiCount)
                {
                    case 1:
                        materiGameIsi.text = "Passing adalah memberikan atau memindahkan bola kepada rekan satu tim di atas lapangan dengan cara melemparkan bola tersebut.";
                        break;
                    case 2:
                        materiGameIsi.text = "Chest pass adalah passing ketika siku menekuk sehingga bolanya sejajar dengan dada dan kedua tangan memegang bola";
                        break;
                    case 3:
                        materiGameIsi.text = "Overhead pass adalah passing ketika bola diposisikan di atas kepala dan siku menekuk. Bola dilemparkan sampai posisi tangan jadi lurus.";
                        break;
                    case 4:
                        materiGameIsi.text = "Bounce pass dilakukan dengan cara memantulkan bola ke lantai di depan rekan tim guna mengoper bola ke rekan satu tim.";
                        break;
                }
                break;

            case 3:
                switch (materiCount)
                {
                    case 1:
                        materiGameIsi.text = "Menggiring bola atau dribble adalah cara bola digiring dengan dipantul-pantulkan ke tanah menggunakan satu tangan dari satu tempat ke tempat lain";
                        break;
                    case 2:
                        materiGameIsi.text = "Dribble rendah gunanya untuk menyusup,mengacaukan pertahanan lawan, dan mengecoh lawan.";
                        break;
                    case 3:
                        materiGameIsi.text = "Dribble tinggi gunanya untuk memperoleh posisi mendekati basket atau ring lawan secepat - cepatnya.";
                        break;
                }
                break;

            case 4:
                switch (materiCount)
                {
                    case 1:
                        materiGameIsi.text = "Shooting adalah melepaskan (menembakkan) bola ke dalam keranjang atau ring basket lawan untuk mendapatkan poin.";
                        break;
                    case 2:
                        materiGameIsi.text = "Set shoot adalah memegang bola dengan kedua tangan sambil menekuk lutut. Lenturkan jari dan berikan tambahan dorongan dari lengan.";
                        break;
                    case 3:
                        materiGameIsi.text = "Lay up shoot adalah lemparan bola dengan satu tangan menuju target. Lemparan tersebut dilakukan sambil melompat seakan melayang.";
                        break;
                    case 4:
                        materiGameIsi.text = "Jump shoot ketika pemain tidak bergerak maju ataupun mundur. Lalu melompat di saat titik tertinggi untuk melempar bola";
                        break;
                    case 5:
                        materiGameIsi.text = "Slam dunk adalah memasukkan bola ke dalam keranjang dengan telapak tangan menyentuh besi ring basket setelah bola melewati ring.";
                        break;
                }
                break;

            case 5:
                switch (materiCount)
                {
                    case 1:
                        materiGameIsi.text = "Pivot adalah gerakan memutar tubuh dengan menggunakan salah satu kaki sebagai poros sekaligus sebagai tumpuan tubuh.";
                        break;
                    case 2:
                        materiGameIsi.text = "Tumpuan kaki pivot yang digunakan adalah kaki yang paling kuat";
                        break;
                    case 3:
                        materiGameIsi.text = "Rebound adalah teknik memanfaatkan pantulan bola yang gagal masuk ke dalam ring basket. Jika tembakan yang gagal berasal dari tim.";
                        break;
                }
                break;

            case 6:
                switch (materiCount)
                {
                    case 1:
                        materiGameIsi.text = "Setiap tim dalam permainan bola basket terdiri dari lima orang pemain ditambah beberapa pemain cadangan.";
                        break;
                    case 2:
                        materiGameIsi.text = "Perbasi menetapkan beberapa aturan waktu. Pertama, peraturan tiga detik. Saat berada di area pertahanan lawan.";
                        break;
                    case 3:
                        materiGameIsi.text = "Peraturan delapan detik. Waktu yang dibolehkan sebuah tim untuk memainkan bola di daerah pertahanannya sendiri adalah selama delapan detik.";
                        break;
                    case 4:
                        materiGameIsi.text = "Peraturan 24 detik. Ini merupakan waktu yang dibolehkan untuk sebuah tim dalam melakukan serangan. Tidak boleh lebih.";
                        break;
                    case 5:
                        materiGameIsi.text = "Tidak diperboleh memukul atau meninju bola. Bola hanya boleh dibawa dengan cara di-dribble.";
                        break;
                    case 6:
                        materiGameIsi.text = "Batas yang diijinkan seorang pemain melakukan pelanggaran adalah empat kali.";
                        break;
                    case 7:
                        materiGameIsi.text = "Jika seorang pemain melakukan dribble kemudian berhenti dan memegang bola dengan kedua tangannya, maka pemain tidak diperbolehkan untuk melakukan dribble lagi.";
                        break;
                }
                break;

        }
    }

    IEnumerator MateriAnimationUp(Vector3 start, Vector3 end)
    {
        materiMove = true;
        float percentage = 0;
        elapsed = 0;
        while (percentage < 1f)
        {
            elapsed += Time.deltaTime;
            percentage = elapsed / duration;

            transform.localPosition = Vector3.Lerp(start, end, curve.Evaluate(percentage));

            yield return null;
        }
        if (percentage >= 1f)
        {
            materiPause = true;
            materiUp = true;
            ActivateMateriGameIsiUI();
        }
        transform.localPosition = end;
    }

    IEnumerator MateriAnimationDown(Vector3 start, Vector3 end)
    {
        materiMove = false;
        materiUp = false;
        materiPause = false;
        float percentage = 0;
        elapsed = 0;
        while (percentage < 1f)
        {
            elapsed += Time.deltaTime;
            percentage = elapsed / duration;

            transform.localPosition = Vector3.Lerp(start, end, curve.Evaluate(percentage));

            yield return null;
        }
        transform.localPosition = end;
    }

    void ActivateMateriGameIsiUI()
    {
        materiGameIsiUI.SetActive(true);
        soundScript.soalShowSound.Play();
    }

    public void MateriShow()
    {
        StartCoroutine(MateriAnimationUp(startMateriDynamic, endMateri));
    }

    public void MateriClick()
    {
        if (materiUp == true)
        {
            StopAllCoroutines();
            materiGameIsiUI.SetActive(false);
            StartCoroutine(MateriAnimationDown(endMateri, startMateri));
            soalGameScript.SoalPlay();

            if (materiCount < materiTarget)
            {
                ballScript.startGame();
            }
        }
    }
}