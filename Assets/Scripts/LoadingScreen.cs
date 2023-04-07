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
        Load();
    }

    void Load()
    {
        while(slider.value < 1)
        {
            slider.value += 0.01f;
        }

        SceneManager.LoadScene("StartScene");
    }
}
