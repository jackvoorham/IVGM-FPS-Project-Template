using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisguiseHUD : MonoBehaviour
{
    PlayerCharacterController player;
    public CanvasGroup disguiseCanvasGroup;
    public float disguiseAlpha = .8f;
    void Start()
    {
        player = FindObjectOfType<PlayerCharacterController>();
        DebugUtility.HandleErrorIfNullFindObject<PlayerCharacterController, FeedbackFlashHUD>(player, this);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.disguiseIsOn)
        {
            disguiseCanvasGroup.gameObject.SetActive(true);
            disguiseCanvasGroup.alpha = disguiseAlpha;
        } 
        else
        {
            disguiseCanvasGroup.gameObject.SetActive(false);
        }
    }
}
