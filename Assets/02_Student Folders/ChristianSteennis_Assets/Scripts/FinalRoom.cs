using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRoom : MonoBehaviour
{

    public Collider barricade;
    EnemyManager enemyManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyManager.numberOfEnemiesRemaining == 0) {
            barricade.gameObject.SetActive(false);
        }
    }
}
