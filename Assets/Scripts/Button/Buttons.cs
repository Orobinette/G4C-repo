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

    


/*********
*FUNCTIONS
**********/

    void Start() 
    {
        gameControllerObj = GameObject.FindWithTag("GameController");
        globalVariables = gameControllerObj.GetComponent<GlobalVariables>();
        audioControls = gameControllerObj.GetComponent<AudioControls>();
    }

    //Sprites
    public void Hovering()
    {
        button.image.sprite = hoverSprite;
    }
    public void NotHovering() 
    {
        button.image.sprite = defaultSprite;
    }

     //Scene Management
    public void ChangeScene(string scene) 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    }

    public void SetDifficulty(string difficulty) 
    {   
        globalVariables.difficulty = difficulty;
    }
}

