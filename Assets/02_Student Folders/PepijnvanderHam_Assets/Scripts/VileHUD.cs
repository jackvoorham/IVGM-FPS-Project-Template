using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VileHUD : MonoBehaviour
{
    PlayerCharacterController player;

    Health m_PlayerHealth;

    [Header("Vial Power Up")]

    public CanvasGroup vialCanvasGroup;
    public float vialMaxAlpha = .8f;

    public float viallinesFrequency = 4f;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerCharacterController>();
        DebugUtility.HandleErrorIfNullFindObject<PlayerCharacterController, FeedbackFlashHUD>(player, this);

        m_PlayerHealth = player.GetComponent<Health>();
        DebugUtility.HandleErrorIfNullGetComponent<Health, FeedbackFlashHUD>(m_PlayerHealth, this, player.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.vialIsOn)
        {
            vialCanvasGroup.gameObject.SetActive(true);
            vialCanvasGroup.alpha = ((Mathf.Sin(Time.time * viallinesFrequency) / 2) + 0.5f) * vialMaxAlpha;
        } 
        else
        {
            vialCanvasGroup.gameObject.SetActive(false);
        }
    }
}
