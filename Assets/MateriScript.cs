using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MateriScript : MonoBehaviour
{
    Vector3 materiPosition;
    Vector3 materiTambahPosition;
    Vector3 materiIsiPosition;
    Vector3 cameraPosition;

    [SerializeField]
    private AnimationCurve materiTambahCurve;

    public Transition transition;
    public SoundScript soundScript;

    public GameObject Camera;
    public GameObject mainUI;
    public GameObject navbar;
    public GameObject navbarUI;
    public GameObject materiUI;
    public GameObject materiTambahUI;
    public GameObject materiIsiUI;

    public GameObject materiNextBtn;
    public GameObject materiNextBtnUI;
    public GameObject materiPreviousBtn;
    public GameObject materiPreviousBtnUI;
    public GameObject materiExitBtn;
    public GameObject materiExitBtnUI;

    public Text materiIsiTitle;
    public Text materiIsiText;

    public GameObject materiImageObj;
    public GameObject materiImageMediumObj;
    public GameObject materiImageBigObj;
    public Image materiImage;
    public Image materiImageMedium;
    public Image materiImageBig;

    public Sprite none;
    public Sprite bab1_1;
    public Sprite bab1_2;
    public Sprite bab1_3;
    public Sprite bab2_1_1;
    public Sprite bab2_1_2;
    public Sprite bab2_1_3;
    public Sprite bab2_1_4;
    public Sprite bab2_2_1;
    public Sprite bab2_2_2;
    public Sprite bab2_2_3;
    public Sprite bab2_3_1;
    public Sprite bab2_3_2;
    public Sprite bab2_3_3;
    public Sprite bab2_3_4;
    public Sprite bab2_3_5;
    public Sprite bab2_4_1;
    public Sprite bab2_4_2;
    public Sprite bab3_1;

    bool MateriSejarah = false;
    bool MateriTeknik = false;
    bool MateriPassing = false;
    bool MateriDribble = false;
    bool MateriShooting = false;
    bool MateriLainnya = false;
    bool MateriAturan = false;

    public int page = 1;
    public bool subBab; 
    public LogicManager logicManager;

    private void Awake()
    {
        logicManager = GameObject.FindGameObjectWithTag("LogicTag").GetComponent<LogicManager>();
        materiPosition = new Vector3(1620, 960, -1);
        materiTambahPosition = new Vector3(1620, -960, -1);
        materiIsiPosition = new Vector3(1620, -2880, -1);
        soundScript = GameObject.FindGameObjectWithTag("VolumeTag").GetComponent<SoundScript>();
        transition = GameObject.FindGameObjectWithTag("TransitionTag").GetComponent<Transition>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        materiText();
    }

    public void MateriSejarahScene()
    {
        if (logicManager.pressAble)
        {
            soundScript.buttonClickSound.Play();
            MateriSejarah = true;
            MateriTeknik = false;
            MateriPassing = false;
            MateriDribble = false;
            MateriShooting = false;
            MateriLainnya = false;
            MateriAturan = false;
            subBab = false;
            MateriIsiScene();
        }
    }

    public void MateriTeknikScene()
    {
        if (logicManager.pressAble)
        {
            soundScript.buttonClickSound.Play();
            MateriSejarah = false;
            MateriTeknik = true;
            MateriPassing = false;
            MateriDribble = false;
            MateriShooting = false;
            MateriLainnya = false;
            MateriAturan = false;
            MateriTambahScene();
        }

    }

    public void MateriPassingScene()
    {
        if (logicManager.pressAble)
        {
            soundScript.buttonClickSound.Play();
            MateriSejarah = false;
            MateriTeknik = false;
            MateriPassing = true;
            MateriDribble = false;
            MateriShooting = false;
            MateriLainnya = false;
            MateriAturan = false;
            subBab = true;
            MateriIsiScene();
        }
    }

    public void MateriDribbleScene()
    {
        if (logicManager.pressAble)
        {
            soundScript.buttonClickSound.Play();
            MateriSejarah = false;
            MateriTeknik = false;
            MateriPassing = false;
            MateriDribble = true;
            MateriShooting = false;
            MateriLainnya = false;
            MateriAturan = false;
            subBab = true;
            MateriIsiScene();
        }
    }

    public void MateriShootingScene()
    {
        if (logicManager.pressAble)
        {
            soundScript.buttonClickSound.Play();
            MateriSejarah = false;
            MateriTeknik = false;
            MateriPassing = false;
            MateriDribble = false;
            MateriShooting = true;
            MateriLainnya = false;
            MateriAturan = false;
            subBab = true;
            MateriIsiScene();
        }
    }

    public void MateriLainnyaScene()
    {
        if (logicManager.pressAble)
        {
            soundScript.buttonClickSound.Play();
            MateriSejarah = false;
            MateriTeknik = false;
            MateriPassing = false;
            MateriDribble = false;
            MateriShooting = false;
            MateriLainnya = true;
            MateriAturan = false;
            subBab = true;
            MateriIsiScene();
        }
    }

    public void MateriAturanScene()
    {
        if (logicManager.pressAble)
        {
            soundScript.buttonClickSound.Play();
            MateriSejarah = false;
            MateriTeknik = false;
            MateriPassing = false;
            MateriDribble = false;
            MateriShooting = false;
            MateriLainnya = false;
            MateriAturan = true;
            subBab = false;
            MateriIsiScene();
        }
    }

    public void MateriTambahScene()
    {
        if (logicManager.pressAble)
        {
            cameraPosition = Camera.transform.position;
            StartCoroutine(Animation(Camera, cameraPosition, materiTambahPosition));
            navbar.SetActive(false);
            navbarUI.SetActive(false);
            materiTambahUI.SetActive(true);
            materiIsiUI.SetActive(false);
        }
    }
    public void MateriIsiScene()
    {
        if (logicManager.pressAble)
        {
            cameraPosition = Camera.transform.position;
            transition.AnimationFunction();
            StartCoroutine(MateriIsiShow());
        }
    }

    public void MateriOut()
    {
        if (logicManager.pressAble)
        {
            soundScript.buttonClickSound.Play();
            cameraPosition = Camera.transform.position;
            transition.AnimationFunction();
            StartCoroutine(MateriOutShow());
        }
    }

    public void MateriOutNoTransition()
    {
        if (logicManager.pressAble)
        {
            soundScript.buttonClickSound.Play();
            cameraPosition = Camera.transform.position;
            StartCoroutine(Animation(Camera, cameraPosition, materiPosition));
            materiUI.SetActive(true);
            materiTambahUI.SetActive(false);
            materiIsiUI.SetActive(false);
            navbar.SetActive(true);
            navbarUI.SetActive(true);
        }
    }

    IEnumerator MateriIsiShow()
    {
        yield return new WaitForSeconds(0.5f);
        Camera.transform.localPosition = materiIsiPosition;
        materiUI.SetActive(false);
        materiTambahUI.SetActive(false);
        materiIsiUI.SetActive(true);
        navbar.SetActive(false);
        navbarUI.SetActive(false);
    }

    IEnumerator MateriOutShow()
    {
        yield return new WaitForSeconds(0.5f);
        page = 1;
        if (!subBab)
        {
            Camera.transform.localPosition = materiPosition;
            mainUI.SetActive(true);
            navbar.SetActive(true);
            navbarUI.SetActive(true);
            materiUI.SetActive(true);
            materiTambahUI.SetActive(false);
            materiIsiUI.SetActive(false);
            materiImageObj.SetActive(true);
        }
        else
        {
            Camera.transform.localPosition = materiTambahPosition;
            mainUI.SetActive(true);
            navbar.SetActive(false);
            navbarUI.SetActive(false);
            materiUI.SetActive(false);
            materiTambahUI.SetActive(true);
            materiIsiUI.SetActive(false);
            materiImageObj.SetActive(true);
        }
    }

    public void materiIsi()
    {
        materiUI.SetActive(false);
        materiIsiUI.SetActive(true);
    }

    public void materiIsiPrevious()
    {
        page = page - 1;
    }

    public void materiIsiNext()
    {
        page = page + 1;
    }

    public void materiText()
    {
        if (MateriSejarah == true)
        {
            switch (page)
            {
                case 1:
                    materiIsiTitle.text = "SEJARAH";
                    materiImage.sprite = bab1_1;
                    materiImageObj.SetActive(true);
                    materiImageMedium.sprite = none;
                    materiImageMediumObj.SetActive(false);
                    materiImageBig.sprite = none;
                    materiImageBigObj.SetActive(false);
                    materiIsiText.text = "Bola basket merupakan salah satu contoh olahraga bola besar. Permainan ini berlangsung dengan cara mempertandingkan dua tim basket dan berebut bola untuk dimasukkan ke dalam ring lawan. Skor yang didapatkan sangat tergantung dari cara masuknya bola. Skor yang akan kalian dapatkan kalau berhasil mencetak skor berkisar satu sampai tiga poin.";
                    materiPreviousBtn.SetActive(false);
                    materiPreviousBtnUI.SetActive(false);
                    materiNextBtn.SetActive(true);
                    materiNextBtnUI.SetActive(true);
                    break;

                case 2:
                    materiIsiTitle.text = "SEJARAH";
                    materiImage.sprite = bab1_2;
                    materiImageObj.SetActive(true);
                    materiImageMedium.sprite = none;
                    materiImageMediumObj.SetActive(false);
                    materiImageBig.sprite = none;
                    materiImageBigObj.SetActive(false);
                    materiIsiText.text = "James Naismith yang mencatatkan namanya dalam sejarah sebagai pencetus permainan bola basket ini. Awalnya ide tersebut muncul karena saat musim dingin, banyak permainan olahraga yang tidak bisa dilakukan oleh para muridnya. Keinginannya untuk membuat sebuah permainan yang dapat dimainkan di dalam ruangan tertutup, menggerakannya untuk membuat permainan bola basket.";
                    materiPreviousBtn.SetActive(true);
                    materiPreviousBtnUI.SetActive(true);
                    materiNextBtn.SetActive(true);
                    materiNextBtnUI.SetActive(true);
                    break;

                case 3:
                    materiIsiTitle.text = "SEJARAH";
                    materiImage.sprite = bab1_3;
                    materiImageObj.SetActive(true);
                    materiImageMedium.sprite = none;
                    materiImageMediumObj.SetActive(false);
                    materiImageBig.sprite = none;
                    materiImageBigObj.SetActive(false);
                    materiIsiText.text = "Sejarah mencatat, pada tahun 1920, terjadi eksodus warga negara China ke negara-negara Asia Tenggara, salah satunya Indonesia. Sementara itu, China merupakan salah satu sasaran utama dari Young Men’s Christian Association untuk dijadikan tempat penyebaran permainan bola basket. China yang lebih dulu mengenal permainan bola basket dua puluh tahun sebelumnya, turut membawa permainan ini ke Indonesia saat terjadi eksodus tersebut.";
                    materiPreviousBtn.SetActive(true);
                    materiPreviousBtnUI.SetActive(true);
                    materiNextBtn.SetActive(false);
                    materiNextBtnUI.SetActive(false);
                    break;
            }

        }
        if (MateriTeknik == true)
        {

        }
        if (MateriPassing == true)
        {
            switch (page)
            {
                case 1:
                    materiIsiTitle.text = "PASSING";
                    materiImage.sprite = none;
                    materiImageObj.SetActive(false);
                    materiImageMedium.sprite = bab2_1_1;
                    materiImageMediumObj.SetActive(true);
                    materiImageBig.sprite = none;
                    materiImageBigObj.SetActive(false);
                    materiIsiText.text = "Setelah menguasai teknik memegang bola, kita perlu banget menguasai teknik mengoper bola ke teman. Sebab dalam permainan , kita tidak mungkin membawa bola tanpa melakukan operan sama sekali. Teknik ini memiliki beberapa cara";
                    materiPreviousBtn.SetActive(false);
                    materiPreviousBtnUI.SetActive(false);
                    materiNextBtn.SetActive(true);
                    materiNextBtnUI.SetActive(true);
                    break;

                case 2:
                    materiIsiTitle.text = "CHEST PASS";
                    materiImage.sprite = none;
                    materiImageObj.SetActive(false);
                    materiImageMedium.sprite = none;
                    materiImageMediumObj.SetActive(false);
                    materiImageBig.sprite = bab2_1_2;
                    materiImageBigObj.SetActive(true);
                    materiIsiText.text = "Jika kalian menonton pertandingan bola basket, pernah tidak memperhatikan seorang pemain melakukan operan yang sikunya menekuk sehingga bolanya sejajar dengan dada dan kedua tangan memegang bola? Kalau pernah, itulah yang dimaksud chest pass.";
                    materiPreviousBtn.SetActive(true);
                    materiPreviousBtnUI.SetActive(true);
                    materiNextBtn.SetActive(true);
                    materiNextBtnUI.SetActive(true);
                    break;

                case 3:
                    materiIsiTitle.text = "OVERHEAD PASS";
                    materiImage.sprite = none;
                    materiImageObj.SetActive(false);
                    materiImageMedium.sprite = none;
                    materiImageMediumObj.SetActive(false);
                    materiImageBig.sprite = bab2_1_3;
                    materiImageBigObj.SetActive(true);
                    materiIsiText.text = "Cara melakukan operan ini adalah dengan kedua tangan memegang bola dan diposisikan di atas kepala dan siku menekuk. Dengan bertumpu pada lekukan tangan, bola dilemparkan sampai posisi tangan jadi lurus. Oh ya, agar maksimal, bola dilepaskan dengan menggunakan jentikan ujung jari-jari.";
                    materiPreviousBtn.SetActive(true);
                    materiPreviousBtnUI.SetActive(true);
                    materiNextBtn.SetActive(true);
                    materiNextBtnUI.SetActive(true);
                    break;

                case 4:
                    materiIsiTitle.text = "BOUNCE PASS";
                    materiImage.sprite = none;
                    materiImageObj.SetActive(false);
                    materiImageMedium.sprite = none;
                    materiImageMediumObj.SetActive(false);
                    materiImageBig.sprite = bab2_1_4;
                    materiImageBigObj.SetActive(true);
                    materiIsiText.text = "Cara melakukan operan ini adalah dengan kedua tangan memegang bola dan diposisikan di atas kepala dan siku menekuk. Dengan bertumpu pada lekukan tangan, bola dilemparkan sampai posisi tangan jadi lurus. Oh ya, agar maksimal, bola dilepaskan dengan menggunakan jentikan ujung jari-jari.";
                    materiPreviousBtn.SetActive(true);
                    materiPreviousBtnUI.SetActive(true);
                    materiNextBtn.SetActive(false);
                    materiNextBtnUI.SetActive(false);
                    break;
            }
        }
        if (MateriDribble == true)
        {
            switch (page)
            {
                case 1:
                    materiIsiTitle.text = "DRIBBLE";
                    materiImage.sprite = bab2_2_1;
                    materiImageObj.SetActive(true);
                    materiImageMedium.sprite = none;
                    materiImageMediumObj.SetActive(false);
                    materiImageBig.sprite = none;
                    materiImageBigObj.SetActive(false);
                    materiIsiText.text = "Menggiring bola adalah salah satu teknik mengontrol bola yang dilakukan dengan cara bola digiring dengan dipantul-pantulkan ke tanah menggunakan satu tangan dari satu tempat ke tempat lain, atau digiring mendekati daerah lawan agar bola tidak direbut lawan. Prinsip menggiring bola adalah bola selalu dekat dengan penggiring bola dan jauh dari lawan.";
                    materiPreviousBtn.SetActive(false);
                    materiPreviousBtnUI.SetActive(false);
                    materiNextBtn.SetActive(true);
                    materiNextBtnUI.SetActive(true);
                    break;

                case 2:
                    materiIsiTitle.text = "DRIBBLE RENDAH";
                    materiImage.sprite = none;
                    materiImageObj.SetActive(false);
                    materiImageMedium.sprite = none;
                    materiImageMediumObj.SetActive(false);
                    materiImageBig.sprite = bab2_2_2;
                    materiImageBigObj.SetActive(true);
                    materiIsiText.text = "Dribble rendah adalah gerakan menggiring bola dengan memantulkan bola dengan ketinggian rendah. Biasanya digunakan untuk menyusup,mengacaukan pertahanan lawan, dan mengecoh lawan.";
                    materiPreviousBtn.SetActive(true);
                    materiPreviousBtnUI.SetActive(true);
                    materiNextBtn.SetActive(true);
                    materiNextBtnUI.SetActive(true);
                    break;

                case 3:
                    materiIsiTitle.text = "DRIBBLE TINGGI";
                    materiImage.sprite = none;
                    materiImageObj.SetActive(false);
                    materiImageMedium.sprite = none;
                    materiImageMediumObj.SetActive(false);
                    materiImageBig.sprite = bab2_2_3;
                    materiImageBigObj.SetActive(true);
                    materiIsiText.text = "Dribble tinggi adalah gerakan menggiring bola dengan pantulan bola yang tinggi. Biasanya digunakan untuk memperoleh posisi mendekati basket atau ring lawan secepat - cepatnya.";
                    materiPreviousBtn.SetActive(true);
                    materiPreviousBtnUI.SetActive(true);
                    materiNextBtn.SetActive(false);
                    materiNextBtnUI.SetActive(false);
                    break;
            }
        }
        if (MateriShooting == true)
        {
            switch (page)
            {
                case 1:
                    materiIsiTitle.text = "SHOOTING";
                    materiImage.sprite = none;
                    materiImageObj.SetActive(false);
                    materiImageMedium.sprite = bab2_3_1;
                    materiImageMediumObj.SetActive(true);
                    materiImageBig.sprite = none;
                    materiImageBigObj.SetActive(false);
                    materiIsiText.text = "Kemampuan mencetak skor sangat bergantung pada skill dalam melakukan shooting bola ke dalam ring lawan. Semakin baik kemampuan shooting, semakin besar kemungkinan untuk meraup poin-poin tinggi. Sebab posisi menembak menentukan besarnya nilai yang akan didapatkan.";
                    materiPreviousBtn.SetActive(false);
                    materiPreviousBtnUI.SetActive(false);
                    materiNextBtn.SetActive(true);
                    materiNextBtnUI.SetActive(true);
                    break;

                case 2:
                    materiIsiTitle.text = "SET SHOOT";
                    materiImage.sprite = none;
                    materiImageObj.SetActive(false);
                    materiImageMedium.sprite = none;
                    materiImageMediumObj.SetActive(false);
                    materiImageBig.sprite = bab2_3_2;
                    materiImageBigObj.SetActive(true);
                    materiIsiText.text = "Memegang bola dengan kedua tangan sambil menekuk lutut dalam keadaan memasang kuda-kuda. Sementara badan masih tegak, tajamkan pandangan ke target. Lenturkan jari dan berikan tambahan dorongan dari lengan.";
                    materiPreviousBtn.SetActive(true);
                    materiPreviousBtnUI.SetActive(true);
                    materiNextBtn.SetActive(true);
                    materiNextBtnUI.SetActive(true);
                    break;

                case 3:
                    materiIsiTitle.text = "LAY UP SHOOT";
                    materiImage.sprite = none;
                    materiImageObj.SetActive(false);
                    materiImageMedium.sprite = none;
                    materiImageMediumObj.SetActive(false);
                    materiImageBig.sprite = bab2_3_3;
                    materiImageBigObj.SetActive(true);
                    materiIsiText.text = "Pemain melakukan lemparan bola dengan satu tangan menuju target. Lemparan tersebut dilakukan sambil melompat seakan melayang.";
                    materiPreviousBtn.SetActive(true);
                    materiPreviousBtnUI.SetActive(true);
                    materiNextBtn.SetActive(true);
                    materiNextBtnUI.SetActive(true);
                    break;

                case 4:
                    materiIsiTitle.text = "JUMP SHOOT";
                    materiImage.sprite = none;
                    materiImageObj.SetActive(false);
                    materiImageMedium.sprite = none;
                    materiImageMediumObj.SetActive(false);
                    materiImageBig.sprite = bab2_3_4;
                    materiImageBigObj.SetActive(true);
                    materiIsiText.text = "Pemain tidak bergerak maju ataupun mundur. Lalu melompat di saat titik tertinggi untuk melempar bola. Prinsip dalam melakukan jump shoot ada empat, yakni bow,eye, elbow, follow through.";
                    materiPreviousBtn.SetActive(true);
                    materiPreviousBtnUI.SetActive(true);
                    materiNextBtn.SetActive(true);
                    materiNextBtnUI.SetActive(true);
                    break;

                case 5:
                    materiIsiTitle.text = "SLAM DUNK";
                    materiImage.sprite = none;
                    materiImageObj.SetActive(false);
                    materiImageMedium.sprite = none;
                    materiImageMediumObj.SetActive(false);
                    materiImageBig.sprite = bab2_3_5;
                    materiImageBigObj.SetActive(true);
                    materiIsiText.text = "Gaya di dalam permainan bola basket di mana seorang pemain berusaha memasukkan bola ke dalam keranjang dengan telapak tangan menyentuh besi ring basket setelah bola melewati ring.";
                    materiPreviousBtn.SetActive(true);
                    materiPreviousBtnUI.SetActive(true);
                    materiNextBtn.SetActive(false);
                    materiNextBtnUI.SetActive(false);
                    break;
            }
        }
        if (MateriLainnya == true)
        {
            switch (page)
            {
                case 1:
                    materiIsiTitle.text = "PIVOT";
                    materiImage.sprite = none;
                    materiImageObj.SetActive(false);
                    materiImageMedium.sprite = bab2_4_1;
                    materiImageMediumObj.SetActive(true);
                    materiImageBig.sprite = none;
                    materiImageBigObj.SetActive(false);
                    materiIsiText.text = "Gerakan memutar tubuh dengan menggunakan salah satu kaki sebagai poros sekaligus sebagai tumpuan tubuh. Pivot dilakukan dengan kedua tangan memegang bola. Pivot biasanya setelah menerima operan dari rekan satu tim karena ingin melindungi bola dari sergapan lawan.";
                    materiPreviousBtn.SetActive(false);
                    materiPreviousBtnUI.SetActive(false);
                    materiNextBtn.SetActive(true);
                    materiNextBtnUI.SetActive(true);
                    break;


                case 2:
                    materiIsiTitle.text = "REBOUND";
                    materiImage.sprite = none;
                    materiImageObj.SetActive(false);
                    materiImageMedium.sprite = bab2_4_2;
                    materiImageMediumObj.SetActive(true);
                    materiImageBig.sprite = none;
                    materiImageBigObj.SetActive(false);
                    materiIsiText.text = "Teknik memanfaatkan pantulan bola yang gagal masuk ke dalam ring basket. Jika tembakan yang gagal berasal dari tim, rebound berguna memanfaatkan kemelut di depan ring. Namun jika yang tembakannya gagal adalah tim lawan, rebound dapat dimanfaatkan untuk menjauhkan bola dari daerah pertahanan.";
                    materiPreviousBtn.SetActive(true);
                    materiPreviousBtnUI.SetActive(true);
                    materiNextBtn.SetActive(false);
                    materiNextBtnUI.SetActive(false);
                    break;
            }
        }
        if (MateriAturan == true)
        {
            switch (page)
            {
                case 1:
                    materiIsiTitle.text = "PEMAIN";
                    materiImage.sprite = bab3_1;
                    materiImageObj.SetActive(true);
                    materiImageMedium.sprite = none;
                    materiImageMediumObj.SetActive(false);
                    materiImageBig.sprite = none;
                    materiImageBigObj.SetActive(false);
                    materiIsiText.text = "Setiap tim dalam permainan bola basket terdiri dari lima orang pemain ditambah beberapa pemain cadangan. Kelima pemain inti tersebut terbagi pada beberapa posisi, yakni center (5 – C), power forward (4 – PF), small forward (3 – SF), shooting guard (2 – SG), dan point guard (1 – PG).";
                    materiPreviousBtn.SetActive(false);
                    materiPreviousBtnUI.SetActive(false);
                    materiNextBtn.SetActive(true);
                    materiNextBtnUI.SetActive(true);
                    break;

                case 2:
                    materiIsiTitle.text = "WAKTU";
                    materiImage.sprite = none;
                    materiImageObj.SetActive(false);
                    materiImageMedium.sprite = none;
                    materiImageMediumObj.SetActive(false);
                    materiImageBig.sprite = none;
                    materiImageBigObj.SetActive(false);
                    materiIsiText.text = "Perbasi menetapkan beberapa aturan waktu. Pertama, peraturan tiga detik. Saat berada di area pertahanan lawan. \r\n\r\nPeraturan delapan detik. Waktu yang dibolehkan sebuah tim untuk memainkan bola di daerah pertahanannya sendiri adalah selama delapan detik.\r\n\r\nperaturan 24 detik. Ini merupakan waktu yang dibolehkan untuk sebuah tim dalam melakukan serangan. Tidak boleh lebih.";
                    materiPreviousBtn.SetActive(true);
                    materiPreviousBtnUI.SetActive(true);
                    materiNextBtn.SetActive(true);
                    materiNextBtnUI.SetActive(true);
                    break;

                case 3:
                    materiIsiTitle.text = "ATURAN LAIN";
                    materiImage.sprite = none;
                    materiImageObj.SetActive(false);
                    materiImageMedium.sprite = none;
                    materiImageMediumObj.SetActive(false);
                    materiImageBig.sprite = none;
                    materiImageBigObj.SetActive(false);
                    materiIsiText.text = "Tidak diperboleh memukul atau meninju bola.\r\n\r\nBola hanya boleh dibawa dengan cara di-dribble.\r\n\r\nBatas yang diijinkan seorang pemain melakukan pelanggaran adalah empat kali.\r\n\r\nJika seorang pemain melakukan dribble kemudian berhenti dan memegang bola dengan kedua tangannya, maka pemain tidak diperbolehkan untuk melakukan dribble lagi.";
                    materiPreviousBtn.SetActive(true);
                    materiPreviousBtnUI.SetActive(true);
                    materiNextBtn.SetActive(false);
                    materiNextBtnUI.SetActive(false);
                    break;
            }
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

            navbar.transform.localPosition = Vector3.Lerp(start, end, materiTambahCurve.Evaluate(percentageComplete));
            yield return null;
        }

        navbar.transform.localPosition = end;
        logicManager.pressAble = true;
    }
}
