using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip win;
    public AudioClip over;

    void Start()
    {
        Progress.GameWin += GameWin;
        PlayerHealth.GameOver += GameOver;
    }

    private void OnDestroy()
    {
        Progress.GameWin -= GameWin;
        PlayerHealth.GameOver -= GameOver;
    }

    void GameOver()
    {
        audio.clip = over;
        audio.Play();
    }

    void GameWin()
    {
        audio.clip = win;
        audio.Play();
    }
}
