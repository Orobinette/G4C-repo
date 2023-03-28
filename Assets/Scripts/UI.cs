using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{
/*********
*VARIABLES
**********/
    [SerializeField] SceneManagement sceneManagement;

    [SerializeField] TextMeshProUGUI highScoreText;
    
    GameObject gameManagerObj;
    ScoreKeeper scoreKeeper;

    Scene currentScene;


/*********
*FUNCTIONS
**********/

    void Start() 
    {
        currentScene = SceneManager.GetActiveScene();
        if(currentScene.buildIndex == 0)
        {
            gameManagerObj = GameObject.FindWithTag("GameController");
            scoreKeeper = gameManagerObj.GetComponent<ScoreKeeper>();

            highScoreText.text = "HighScore: " + scoreKeeper.highScore.ToString();
        }

    }

    
    public void StartGame() 
    {
        SceneManager.LoadScene("LoadingScene");
        sceneManagement.nextScene = "MainScene";
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("LoadingScene");
        sceneManagement.nextScene = "StartScene";
    }
}
