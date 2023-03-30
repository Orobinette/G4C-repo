using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteButton : MonoBehaviour
{
/**********
*VARIABLES
**********/

    //Class References
    AudioSource audio;
    [SerializeField] Buttons buttons;

    GlobalVariables globalVariables;
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
        audio = gameControllerObj.GetComponent<AudioSource>();
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
            audio.volume = 0;
            globalVariables.muted = true;
        }
        else 
        {
            audio.volume = 1;
            globalVariables.muted = false;
        }
    }
}
