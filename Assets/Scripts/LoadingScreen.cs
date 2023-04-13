using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] Slider slider;

    void Start() 
    {
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

        SceneManager.LoadScene("MainScene");
    }
}
