using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    
    GameObject scoreKeeperObj;
    ScoreKeeper scoreKeeper;

    Scene currentScene;

    void Start() 
    {
        currentScene = SceneManager.GetActiveScene();
        if(currentScene.buildIndex == 0)
        {
            scoreKeeperObj = GameObject.FindWithTag("ScoreKeeper");
            scoreKeeper = scoreKeeperObj.GetComponent<ScoreKeeper>();

            highScoreText.text = "HighScore: " + scoreKeeper.highScore.ToString();
        }

    }

    public void StartGame() 
    {
        SceneManager.LoadScene("MainScene");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
