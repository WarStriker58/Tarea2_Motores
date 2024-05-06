using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource bgMusic;

    private void Start()
    {
        bgMusic = GetComponent<AudioSource>();
    }

    public void TogglePause()
    {
        if (bgMusic != null)
        {
            if (Time.timeScale == 0)
            {
                bgMusic.UnPause();
            }
            else
            {
                bgMusic.Pause();
            }
        }
    }
}