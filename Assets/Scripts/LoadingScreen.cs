using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    GameObject gameControllerObj;
    GlobalVariables globalVariables;

    [SerializeField] Slider slider;

    void Start() 
    {
        gameControllerObj = GameObject.FindWithTag("GameController");
        globalVariables = gameControllerObj.GetComponent<GlobalVariables>();

        slider.value = 0;
        StartCoroutine("Load");
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
        else
        {
            SceneManager.LoadScene(globalVariables.nextScene);
        }
    }
}
