using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSliders : MonoBehaviour
{

    [SerializeField] Slider effectSlider;

    GameObject gameControllerObj;
    GlobalVariables globalVariables;
    AudioSource audioSource;

    void Start() 
    {
        gameControllerObj = GameObject.FindWithTag("GameController");
        globalVariables = gameControllerObj.GetComponent<GlobalVariables>();
        audioSource = gameControllerObj.GetComponent<AudioSource>();

        effectSlider.value = globalVariables.volume;
    }

    void Update() 
    {
        if(globalVariables.muted) 
        {
            effectSlider.value = 0;
        }
    }   

    public void UpdateSlider() 
    {
        audioSource.volume = effectSlider.value;
    }
}
