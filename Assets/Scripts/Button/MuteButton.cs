using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
/**********
*VARIABLES
**********/

    [SerializeField] Button button;
    [SerializeField] Buttons buttons;

    GameObject gameControllerObj;
    GlobalVariables globalVariables;

    //Sprites
    [SerializeField] Sprite mutedSprite;
    [SerializeField] Sprite mutedHoverSprite;
    [SerializeField] Sprite unmutedSprite;
    [SerializeField] Sprite unmutedHoverSprite;


/**********
*FUNCTIONS
**********/

    void Start () 
    {
        gameControllerObj = GameObject.FindWithTag("GameController");
        globalVariables = gameControllerObj.GetComponent<GlobalVariables>();

        if(globalVariables.muted)
        {
            ChangeSprite();
        }

        button.onClick.AddListener(globalVariables.Mute);
    }

    public void ChangeSprite() 
    {
        if(globalVariables.muted)
        {
            buttons.defaultSprite = mutedSprite;
            buttons.hoverSprite = mutedHoverSprite;
        }
        else
        {
            buttons.defaultSprite = unmutedSprite;
            buttons.hoverSprite = unmutedHoverSprite;
        }

        //button.image.sprite = buttons.defaultSprite;
    }
}
