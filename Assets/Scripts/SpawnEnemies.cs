using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemy1;
    public Transform playerLocation;
    float randX;
    float randY;
    public int randQuadrant;//used to determine whether they'll spawn from in terms of NESW
    Vector2 spawnPoint;
    public float spawnRate = 1f;
    float nextSpawn = 0.0f;

    void Update()
    {
        if (GameObject.Find("PlayerSprite") != null)
        {
            if (Time.time > nextSpawn)
            {
                nextSpawn = Time.time + spawnRate;
                PickSpawn();
                Instantiate(enemy1, spawnPoint, Quaternion.identity);
            }
        }
    }

    void PickSpawn()
    {
        randQuadrant = Random.Range(0, 4);
        if (randQuadrant == 0)//North Spawn
        {
            randX = Random.Range(-20f, 20f);
            spawnPoint = new Vector2(randX, 20f);
            spawnPoint = new Vector2(spawnPoint.x + playerLocation.position.x, spawnPoint.y + playerLocation.position.y);
        }
        if (randQuadrant == 1)//South Spawn
        {
            randX = Random.Range(-20f, 20f);
            spawnPoint = new Vector2(randX, -20f);
            spawnPoint = new Vector2(spawnPoint.x + playerLocation.position.x, spawnPoint.y + playerLocation.position.y);
        }
        if (randQuadrant == 2)//East Spawn
        {
            randY = Random.Range(-20f, 20f);
            spawnPoint = new Vector2(20f, randY);
            spawnPoint = new Vector2(spawnPoint.x + playerLocation.position.x, spawnPoint.y + playerLocation.position.y);
        }
        if (randQuadrant == 3)//West Spawn
        {
            randY = Random.Range(-20f, 20f);
            spawnPoint = new Vector2(-20f, randY);
            spawnPoint = new Vector2(spawnPoint.x + playerLocation.position.x, spawnPoint.y + playerLocation.position.y);
        }
    }
}
