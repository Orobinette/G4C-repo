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

        
        MuteSlider();
    }  

    public void UpdateSlider() 
    {
        audioSource.volume = effectSlider.value;
    }

    public void MuteSlider() 
    {
        if(globalVariables.muted)
        {
            effectSlider.value = 0;
        }
        else  
        {
            effectSlider.value = globalVariables.lastVolume; 
        }
    }
}
