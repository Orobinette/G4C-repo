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
    AudioSource audioSource;

    public int highScore;
    [SerializeField] TextMeshProUGUI highScoreText;

    public bool muted;
    public float lastVolume;

    public string difficulty;
    public bool normalUnlocked;

    public string nextScene;


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
        //highScoreText.text = instance.highScore.ToString();

        lastVolume = 1;
        muted = false;

        audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.volume = 1;

        normalUnlocked = false;
    }

    public void Mute() 
    {
        if(!muted) 
        {
            lastVolume = audioSource.volume;
            audioSource.volume = 0;
            muted = true;
        }
        else 
        {
            audioSource.volume = lastVolume;
            muted = false;
        }
    }

}
