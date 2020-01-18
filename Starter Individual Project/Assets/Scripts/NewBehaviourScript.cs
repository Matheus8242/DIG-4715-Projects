using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip backgroundSong;
    
    void Start()
    {
        musicSource.clip = backgroundSong;
    }

    void Update()
    {
        musicSource.Play();
    }
}
