using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRoom : MonoBehaviour
{

    public Collider barricade;
    EnemyManager enemyManager;
    SkeletonManager skeletonManager;
    int remainingEnemies;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
        skeletonManager = FindObjectOfType<SkeletonManager>();
    }
    
    void OnCollisionEnter(Collision ander) {
        if (ander.gameObject.GetComponent<PlayerCharacterController>()) {
            GetComponent<DisplayMessage>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        remainingEnemies = enemyManager.numberOfEnemiesRemaining + skeletonManager.numberOfEnemiesRemaining;
        if (remainingEnemies == 0 && barricade.enabled) {
            barricade.enabled = false;
            SpawnLastEnemies();
        }
    }

    void SpawnLastEnemies() {
        Instantiate(enemy, new Vector3(8.0f, 0.25f, -2.0f), Quaternion.identity);
        Instantiate(enemy, new Vector3(8.0f, 0.25f, -13.0f), Quaternion.identity);
    }

}
