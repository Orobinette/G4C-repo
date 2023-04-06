using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
/*********
*VARIABLES
*********/

    [SerializeField] Button button;

    GameObject gameControllerObj;
    GlobalVariables globalVariables;
    AudioControls audioControls;

    public Sprite defaultSprite;
    public Sprite hoverSprite;

    [SerializeField] Sprite mutedSprite;
    [SerializeField] Sprite mutedHoverSprite;
    [SerializeField] Sprite unmutedSprite;
    [SerializeField] Sprite unmutedHoverSprite;


/*********
*FUNCTIONS
**********/

    void Start() 
    {
        gameControllerObj = GameObject.FindWithTag("GameController");
        globalVariables = gameControllerObj.GetComponent<GlobalVariables>();
        audioControls = gameControllerObj.GetComponent<AudioControls>();

        if(this.gameObject.tag == "Mute Button" && globalVariables.muted)
        {
            ChangeSprite();
        }
    }

    public void Hovering()
    {
        button.image.sprite = hoverSprite;
    }
    public void NotHovering() 
    {
        button.image.sprite = defaultSprite;
    }

    public void ChangeSprite() 
    {
        if(globalVariables.muted)
        {
            defaultSprite = mutedSprite;
            hoverSprite = mutedHoverSprite;
        }
        else
        {
            defaultSprite = unmutedSprite;
            hoverSprite = unmutedHoverSprite;
        }

        button.image.sprite = defaultSprite;
    }


    public void Mute() 
    {
        audioControls.Mute();
    }


    public void StartGame() 
    {
        SceneManager.LoadScene("MainScene");
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");
    }

    public void LoadOptionsMenu() 
    {
        SceneManager.LoadScene("OptionsScene");
    }

    public void LoadAboutMenu() 
    {
        SceneManager.LoadScene("AboutScene");
    }
}

