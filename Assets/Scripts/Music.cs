using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Music : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip introClip;
    [SerializeField] AudioClip music;

    float introLength;

    IEnumerator Start() 
    {
        introLength = introClip.length;

        audioSource.clip = introClip;
        audioSource.Play();
        yield return new WaitForSeconds(4.1f);
        StartSong();
    }

    void StartSong() 
    {
        audioSource.clip = music;
        audioSource.Play();
        audioSource.loop = true;
    }
}
