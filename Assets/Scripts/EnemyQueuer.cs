using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyQueuer : MonoBehaviour
{
    public Transform playerLocation;
    public float queueDistance;
    public Transform enemyLocation;
    public float distanceToPlayer;

    private void Awake()
    {
        enemyLocation = this.transform;
        playerLocation = GameObject.Find("PlayerSprite").transform;
    }
    private void Update()
    {
        Vector2 distanceVector = playerLocation.position - enemyLocation.position;
        distanceToPlayer = distanceVector.magnitude;
        if (distanceToPlayer >= queueDistance)
        {
            SpawnEnemies.enemySpawnerScript.SpawnQueue += 1;
            Destroy(gameObject);
        }
    }
}

