using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> truckList = new List<GameObject>();

    public int score = 0;
    public TextMeshProUGUI scoreText;

    void Start() 
    {
        InvokeRepeating("SpawnTruck", 3f, 5f);
        scoreText.text = "0";
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
        scoreText.text = score.ToString();
    }

}
