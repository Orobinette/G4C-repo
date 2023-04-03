using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneManagement : MonoBehaviour
{
/*********
*VARIABLES
**********/
    [SerializeField] TextMeshProUGUI highScoreText;
    
    GameObject gameManagerObj;
    GlobalVariables globalVariables;

    Scene currentScene;

    [HideInInspector] public string nextScene;


/*********
*FUNCTIONS
**********/

    void Start() 
    {
        currentScene = SceneManager.GetActiveScene();
        if(currentScene.buildIndex == 0)
        {
            gameManagerObj = GameObject.FindWithTag("GameController");
            globalVariables = gameManagerObj.GetComponent<GlobalVariables>();

            highScoreText.text = "HighScore: " + globalVariables.highScore.ToString();
        }

    }

    
    public void StartGame() 
    {
        SceneManager.LoadScene("LoadingScene");
        nextScene = "MainScene";
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("LoadingScene");
        nextScene = "StartScene";
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
