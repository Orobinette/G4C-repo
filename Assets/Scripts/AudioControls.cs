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
    GameObject musicPlayer;
    GlobalVariables globalVariables;
    AudioSource audioSource;
    AudioSource musicSource;

    //Other
    [SerializeField] Slider effectSlider;
    

/*********
*FUNCTIONS
**********/

    void Start() 
    {
        gameControllerObj = GameObject.FindWithTag("GameController");
        musicPlayer = gameControllerObj.transform.GetChild(0).gameObject;

        globalVariables = gameControllerObj.GetComponent<GlobalVariables>();
        audioSource = gameControllerObj.GetComponent<AudioSource>();
        musicSource = musicPlayer.GetComponent<AudioSource>();

        
        MuteSlider();
    }  

    public void UpdateSlider() 
    {
        audioSource.volume = effectSlider.value;
        musicSource.volume = effectSlider.value;
    }

    public void MuteSlider() 
    {
        if(globalVariables.muted)
        {
            effectSlider.value = 0;
        }
        else if(!globalVariables.muted)
        {
            effectSlider.value = globalVariables.lastVolume; 
        }
    }
}
