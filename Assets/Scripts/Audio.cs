using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    public AudioClip positiveSound;
    public AudioClip negativeSound;
    public AudioClip pauseSound;
    public AudioClip clickSound;
    public AudioClip countdownSound;

    public void PlaySound(AudioClip soundEffect) 
    {
        audioSource.clip = soundEffect;
        audioSource.Play(); 
    }
}
