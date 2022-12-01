using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairVerifier : MonoBehaviour
{
    private Transform thisRepairKit;
    public float distanceFromKits;
    public Transform playerLocation;
    float distanceToPlayer;
    public float queueDistance;
    int foundRepairs = 0;
    private void Awake()
    {
        thisRepairKit = this.GetComponent<Transform>();
        GameObject[] repairList = GameObject.FindGameObjectsWithTag("Repair");
        for (int i = 0; i < repairList.Length; i++)
        {
            Vector2 distanceVector = repairList[i].transform.position - thisRepairKit.position;
            distanceFromKits = distanceVector.magnitude;
            if (distanceFromKits < 5)
                foundRepairs++;
        }
        if(foundRepairs >= 2)
            Destroy(gameObject);
        playerLocation = GameObject.Find("PlayerSprite").transform;
    }

    private void Update()
    {
        Vector2 playerDistanceVector = playerLocation.position - thisRepairKit.transform.position;
        distanceToPlayer = playerDistanceVector.magnitude;
        if (distanceToPlayer >= queueDistance)
        {
            RepairSpawner.repairSpawnerScript.repairQueue++;
            Destroy(gameObject);
        }
    }


}
