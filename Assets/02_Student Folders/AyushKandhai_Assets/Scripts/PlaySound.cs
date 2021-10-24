using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource audioSource_Open = null;
    public AudioSource audioSource_Close = null;

    void playSound_Open()
    {
            audioSource_Open.Play();
    }
    void playSound_Close()
    {
            audioSource_Close.Play();
    }
}
