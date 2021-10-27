using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Disguise : MonoBehaviour
{    
    Pickup m_Pickup;
    public float timer = 15f;
    void Start()
    {
        m_Pickup = GetComponent<Pickup>();
        DebugUtility.HandleErrorIfNullGetComponent<Pickup, Pickup_Disguise>(m_Pickup, this, gameObject);

        // Subscribe to pickup action
        m_Pickup.onPick += OnPicked;
    }

    void OnPicked(PlayerCharacterController player)
    {
        if (player && !player.disguiseIsOn)
        {
            player.disguiseIsOn = true;
            player.disguiseTimer = timer;
            Destroy(gameObject);
        }
    }
}
