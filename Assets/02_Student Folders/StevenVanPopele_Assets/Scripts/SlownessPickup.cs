using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlownessPickup : MonoBehaviour
{
    Pickup m_Pickup;
    public float timerLength = 4f;
    void Start()
    {
        m_Pickup = GetComponent<Pickup>();
        DebugUtility.HandleErrorIfNullGetComponent<Pickup, HealthPickup>(m_Pickup, this, gameObject);

        // Subscribe to pickup action
        m_Pickup.onPick += OnPicked;
    }
    void OnPicked(PlayerCharacterController player)
    {
        if (player && !player.slowIsOn)
        {
            player.slowIsOn = true;
            player.slowTimer = timerLength;
        }
    }
}