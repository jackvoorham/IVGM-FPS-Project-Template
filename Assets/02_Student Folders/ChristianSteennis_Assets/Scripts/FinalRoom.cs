using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRoom : MonoBehaviour
{

    public Collider barricade;
    EnemyManager enemyManager;
    SkeletonManager skeletonManager;
    int remainingEnemies;

    // Start is called before the first frame update
    void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
        skeletonManager = FindObjectOfType<SkeletonManager>();
        remainingEnemies = enemyManager.numberOfEnemiesRemaining + skeletonManager.numberOfEnemiesRemaining;
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingEnemies == 0) {
            barricade.gameObject.SetActive(false);
        }
    }

    void OnCollision(Collider ander) {
        if (ander.name == "Player") {
            // display message
        }
    }
}
