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
        while(slider.value < 100)
        {
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
            slider.value += Random.Range(0.05f, 0.1f);
        }
    }
}
