using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    public GameObject TutorialUI;

    public Image tutorialImage;
    public Sprite image1;
    public Sprite image2;
    public Sprite image3;
    public Sprite image4;
    public Sprite image5;

    public Text tutorialText;

    public bool tutorialSwitch = true;
    public bool tutorialPause = false;
    public int tutorialPage = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        tutorialPage = PlayerPrefs.GetInt("tutorialPage");
        PlayerPrefs.SetInt("tutorialPage", tutorialPage);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TutorialPageIsi();
    }

    public void TutorialShow()
    {
        tutorialPause = true;
        if (tutorialPage >= 5)
        {
            tutorialPause = false;
            tutorialSwitch = false;
        }
        if (tutorialSwitch)
        {
            tutorialPause = true;
            TutorialPageIsi();
            TutorialUI.SetActive(true);
        }
    }

    public void TutorialClose()
    {
        tutorialPage = tutorialPage + 1;
        PlayerPrefs.SetInt("tutorialPage", tutorialPage);
        TutorialPageIsi();
        if (tutorialPage >= 5)
        {
            tutorialSwitch = false;
            TutorialUI.SetActive(false);
            tutorialPause = false;
        }
    }

    public void TutorialPageIsi()
    {
        switch (tutorialPage)
        {       
            case 0:
                tutorialImage.sprite = image1;
                tutorialText.text = "Cara memainkan permainan ini dengan cara menekan bola yang keluar";
                break;
            case 1:
                tutorialImage.sprite = image2;
                tutorialText.text = "Tekan materi yang keluar dan baca materinya, hafalkan materi yang muncul untuk menjawab soal di halaman kuis, materi yang sudah ditekan akan dikumpulkan.";
                break;
            case 2:
                tutorialImage.sprite = image3;
                tutorialText.text = "Satu materi yang terkumpul akan hilang jika kamu melewatkan satu bola";
                break;
            case 3:
                tutorialImage.sprite = image4;
                tutorialText.text = "Kumpulkan materi hingga memenuhi materi yang harus dikumpulkan, jika materi sudah terkumpul maka kamu akan dimasukkan ke halaman kuis";
                break;
            case 4:
                tutorialImage.sprite = image5;
                tutorialText.text = "Di dalam kuis kalian harus menjawab pertanyaan dengan benar sesuai materi yang sudah kalian baca";
                break;
        }
    }
}
