using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    public AudioClip positiveSound;
    public AudioClip negativeSound;

    public void PlayPointSound(string type) 
    {
        if(type == "positive")
        {
            audioSource.clip = positiveSound;
        }
        else if(type == "negative")
        {
            audioSource.clip = negativeSound;
        }
        
        audioSource.Play(); 
    }
}
