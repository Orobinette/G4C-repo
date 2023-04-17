using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    /*TODO

    -make if/else statement a list or something for performance reasons
    */

    [SerializeField] AudioSource audioSource;

    public AudioClip positiveSound;
    public AudioClip negativeSound;
    public AudioClip pauseSound;
    public AudioClip clickSound;

    public void PlaySound(string type) 
    {
        if(type == "positive")
        {
            audioSource.clip = positiveSound;
        }
        else if(type == "negative")
        {
            audioSource.clip = negativeSound;
        }
        else if(type == "pause") 
        {
            audioSource.clip = pauseSound;
        }
        else if (type == "click") 
        {
            audioSource.clip = clickSound;
        }
        
        audioSource.Play(); 
    }
}
