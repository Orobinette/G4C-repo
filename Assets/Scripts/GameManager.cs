using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    GameObject scoreKeeperObj;

    [SerializeField] List<GameObject> truckList = new List<GameObject>();

    public int score = 0;
    public TextMeshProUGUI scoreText;

    int time = 10; 
    [SerializeField] TextMeshProUGUI timerText;

    [SerializeField] Audio audio;

    void Start() 
    {
        InvokeRepeating("SpawnTruck", 3f, 5f);
        StartCoroutine("Timer");

        scoreText.text = "Score: 0";
        timerText.text = "Timer: 60";

        scoreKeeperObj = GameObject.FindWithTag("ScoreKeeper");
        scoreKeeper = scoreKeeperObj.GetComponent<ScoreKeeper>();
    }

    void SpawnTruck() 
    {
        Instantiate(truckList[Random.Range(0, truckList.Count)]);
    }

    public void ChangeScore(int scoreModifier) 
    {
        score += scoreModifier;
        if(score < 0)
        {
            score = 0;
        }
        scoreText.text = "Score: " + score.ToString();

        if(scoreModifier > 0)
        {
            audio.PointSound("positive");
        }
        else
        {
            audio.PointSound("negative");
        }
        
    }

    IEnumerator Timer() 
    {
        while(time > 0)
        {
            yield return new WaitForSeconds(1f);

            time --;
            timerText.text = "Timer: " + time.ToString();
        }
        if(time == 0) 
        {
            yield return new WaitForSeconds(1f);

            EndGame();
        }
    }

    void EndGame() 
    {
        SceneManager.LoadScene("GameOverScene");
        if(score > scoreKeeper.highScore)
        {
            scoreKeeper.highScore = score;
        }
    }
}
