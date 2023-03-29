using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GlobalVariables : MonoBehaviour
{
/*********
*VARIABLES
**********/

    public static GlobalVariables instance;

    public int highScore;
    [SerializeField] TextMeshProUGUI highScoreText;

    public bool muted = false;


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
