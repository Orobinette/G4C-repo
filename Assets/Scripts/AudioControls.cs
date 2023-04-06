using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControls : MonoBehaviour
{
/*********
*VARIABLES
**********/

    //Class References
    GameObject gameControllerObj;
    GlobalVariables globalVariables;
    AudioSource audioSource;

    //Other
    [SerializeField] Slider effectSlider;
    

/*********
*FUNCTIONS
**********/

    void Start() 
    {
        gameControllerObj = GameObject.FindWithTag("GameController");
        globalVariables = gameControllerObj.GetComponent<GlobalVariables>();
        audioSource = gameControllerObj.GetComponent<AudioSource>();

        effectSlider.value = globalVariables.volume;
    }

    //TODO: delete globalvariables.volume, replace in script with audiosource.volume, delete line 46 in update "audioSource..."

    void Update() 
    {
        if(globalVariables.muted) 
        {
            if(effectSlider != null)
            {
                effectSlider.value = 0;
            }
        }

        audioSource.volume = globalVariables.volume;
    }   

    public void UpdateSlider() 
    {
        audioSource.volume = effectSlider.value;
        globalVariables.volume = effectSlider.value;
    }

    public void Mute() 
    {
        if(!globalVariables.muted) 
        {
            globalVariables.lastVolume = globalVariables.volume;
            globalVariables.volume = 0;
            globalVariables.muted = true;
        }
        else 
        {
            globalVariables.volume = globalVariables.lastVolume;
            globalVariables.muted = false;

            if(effectSlider != null)
            {
                effectSlider.value = globalVariables.lastVolume;
            }
        }
    }
}
