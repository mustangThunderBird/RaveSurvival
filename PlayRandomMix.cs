using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomMix : MonoBehaviour
{
    public AudioSource audioPlayer;
    public AudioClip[] songs;
    AudioClip song;

    private void Start()
    {
        audioPlayer = gameObject.GetComponent<AudioSource>();
    }

    private void Awake()
    {
        int index = Random.Range(0, songs.Length);
        song = songs[index];
        audioPlayer.clip = song;
        audioPlayer.Play();
    }

    private void Update()
    {
        if (Pause.isGamePaused)
        {
            audioPlayer.Pause();
        }
        else
        {
            audioPlayer.UnPause();
        }
    }
}
