using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteButton : MonoBehaviour
{
/**********
*VARIABLES
**********/

    //Class References
    AudioSource audioSource;
    AudioSource soundAudio;
    [SerializeField] Buttons buttons;

    GlobalVariables globalVariables;
    Audio audio;
    GameObject gameControllerObj;

    //Sprites
    [SerializeField] Sprite muteSprite;
    [SerializeField] Sprite hoverMuteSprite;

    [SerializeField] Sprite defaultSprite;
    [SerializeField] Sprite hoverSprite;

    bool muted = false;


/**********
*FUNCTIONS
**********/

    void Start() 
    {
        gameControllerObj = GameObject.FindWithTag("GameController");
        globalVariables = gameControllerObj.GetComponent<GlobalVariables>();
        audioSource = gameControllerObj.GetComponent<AudioSource>();
        audio = gameControllerObj.GetComponent<Audio>();
    }

    void Update() 
    {
        if(globalVariables.muted) 
        {
            buttons.defaultSprite = muteSprite;
            buttons.hoverSprite = hoverMuteSprite;
        }
        else
        {
            buttons.defaultSprite = defaultSprite;
            buttons.hoverSprite = hoverSprite;
        }    
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
        }
    }
}
