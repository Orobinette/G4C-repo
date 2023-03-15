using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
/*********
*VARIABLES
**********/

    //Class References
    ScoreKeeper scoreKeeper;
    GameObject scoreKeeperObj;

    [SerializeField] Audio audio;

    //Script References
    [SerializeField] List<GameObject> truckList = new List<GameObject>();

    public int score = 0;
    public TextMeshProUGUI scoreText;

    //Timer
    int time = 60; 
    [SerializeField] TextMeshProUGUI timerText;

    //Delay between Trucks spawning
    float delayMin = 3f;
    float delayMax = 5f;


/*********
*FUNCTIONS
**********/

    void Start() 
    {
        StartCoroutine("Timer");
        StartCoroutine("SpawnTruck");

        scoreText.text = "Score: 0";
        timerText.text = "Timer: 60";

        scoreKeeperObj = GameObject.FindWithTag("ScoreKeeper");
        scoreKeeper = scoreKeeperObj.GetComponent<ScoreKeeper>();
    }

    IEnumerator SpawnTruck() 
    {
        while(time > 0)
        {
            yield return new WaitForSeconds(Random.Range(delayMin, delayMax));

            Instantiate(truckList[Random.Range(0, truckList.Count)]);
        }
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

            //Time between truck spawns decreases as the game goes on
            if(time < 40 && time > 20)
            {
                delayMin = 1f;
                delayMax = 2f;
            }
            if(time < 20) 
            {
                delayMin = 0.5f;
                delayMax = 1f;
            }
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