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

    public Sprite defaultSprite;
    public Sprite hoverSprite;


/*********
*FUNCTIONS
**********/

    public void Hovering()
    {
        button.image.sprite = hoverSprite;
    }
    public void NotHovering() 
    {
        button.image.sprite = defaultSprite;
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

