using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
/*********
*VARIABLES
**********/

    public static ScoreKeeper instance;

    public int highScore;
    [SerializeField] TextMeshProUGUI highScoreText;


/*********
*FUNCTIONS
**********/

    void Awake() 
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(instance);
    }

    void Start() 
    {
        highScoreText.text = instance.highScore.ToString();
    }
}
