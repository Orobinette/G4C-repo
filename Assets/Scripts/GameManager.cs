using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
/*********
*VARIABLES
**********/

    //Class References
    GlobalVariables globalVariables;
    GameObject gameControllerObj;
    Audio audio;

    //Script References
    [SerializeField] List<GameObject> truckList = new List<GameObject>();
    [SerializeField] GameObject itemPref;

    //UI
    public int score = 0;
    public TextMeshProUGUI scoreText;

    [SerializeField] GameObject pauseMenu;
    bool paused;

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
        StartCoroutine("SpawnItem");

        scoreText.text = "Score: 0";
        timerText.text = "Timer: 60";

        gameControllerObj = GameObject.FindWithTag("GameController");
        globalVariables = gameControllerObj.GetComponent<GlobalVariables>();
        audio = gameControllerObj.GetComponent<Audio>();

        paused = false;
    }

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    IEnumerator SpawnTruck() 
    {
        while(time > 0)
        {
            yield return new WaitForSeconds(Random.Range(delayMin, delayMax));

            Instantiate(truckList[Random.Range(0, truckList.Count)]);
        }
    }

    IEnumerator SpawnItem() 
    {
        while(time > 0)
        {
            yield return new WaitForSeconds(Random.Range(delayMin, delayMax));
            Instantiate(itemPref);
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
            audio.PlaySound(audio.positiveSound);
            globalVariables.totalCorrectScore++;
        }
        else
        {
            audio.PlaySound(audio.negativeSound);
            globalVariables.totalIncorrectScore--;
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
            /*
            if(time == 5)
            {
                StartCoroutine("Countdown");
            }
            */
        }
    
        if(time == 0) 
        {
            yield return new WaitForSeconds(1f);

            EndGame();
        }
    }

    IEnumerator Countdown() 
    {
        for(int i = 5; i > 0; i--) 
        {
            audio.PlaySound(audio.countdownSound);
            yield return new WaitForSeconds(1f);
        }
    }

    public void Pause() 
    {
        if(!paused) 
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            
            audio.PlaySound(audio.pauseSound);

            paused = true;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;

            paused = false;
        }
    }

    void EndGame() 
    {
        if(score > globalVariables.highScore)
        {
            globalVariables.highScore = score;
        }

        if(globalVariables.normalUnlocked == false)
        {
            globalVariables.normalUnlocked = true;
        }

        globalVariables.nextScene = "StartScene";
        SceneManager.LoadScene("LoadingScene");
    }
}