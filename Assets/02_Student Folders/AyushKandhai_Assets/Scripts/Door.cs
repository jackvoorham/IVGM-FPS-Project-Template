using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator door = null;
    [SerializeField] private bool open = false;
    [SerializeField] private bool close = false;

    [SerializeField] private string Door_open_anim = "";
    [SerializeField] private string Door_close_anim = "";

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            if (open) {
                door.Play(Door_open_anim, 0, 0.0f);
                gameObject.SetActive(false);
            }
            if (close) {
                door.Play(Door_close_anim, 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }

    // void playSound()
    // {
    //     if (open)
    //         audioSource_Open.Play();
    //     else if (close)
    //         audioSource_Close.Play();
    // }
}
