using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour
{
    public Slider sliderLoading;
    public Text loadingPercentage;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadingFunction(1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Loading(int sceneIndex)
    {
        StartCoroutine(LoadingFunction(sceneIndex));
    }

    IEnumerator LoadingFunction(int sceneIndex)
    {
        yield return new WaitForSeconds(0.5f);
        AsyncOperation loading = SceneManager.LoadSceneAsync(sceneIndex);

        while (!loading.isDone)
        {
            float progress = Mathf.Clamp01(loading.progress / 0.9f);
            sliderLoading.value = progress;
            int progressPercentage = Mathf.RoundToInt(progress * 100);
            loadingPercentage.text = progressPercentage + "%";
            yield return null;
        } 
    }
}
