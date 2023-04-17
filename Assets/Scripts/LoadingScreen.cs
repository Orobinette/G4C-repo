using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingScreen : MonoBehaviour
{
    GameObject gameControllerObj;
    GlobalVariables globalVariables;
    LoadingTips loadingTips;

    [SerializeField] Slider slider;
    [SerializeField] TMP_Text tipText;

    //
    void Start() 
    {
        gameControllerObj = GameObject.FindWithTag("GameController");
        globalVariables = gameControllerObj.GetComponent<GlobalVariables>();
        loadingTips = gameControllerObj.GetComponent<LoadingTips>();

        slider.value = 0;

        SetText();
        StartCoroutine("Load");
    }
    
    void SetText() 
    {
        int i = Random.Range(0, loadingTips.tips.Count);
        tipText.text = loadingTips.tips[i];
    }
    IEnumerator Load()
    {
        while(slider.value < 1)
        {
            yield return new WaitForSeconds(0.02f);

            slider.value += 0.01f;
        }

        if(globalVariables.nextScene == "StartScene")
        {
            globalVariables.nextScene = "MainScene";
            SceneManager.LoadScene("StartScene");
        }
        else if(globalVariables.nextScene == "MainScene")
        {
            SceneManager.LoadScene("MainScene");
        }
        else 
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
