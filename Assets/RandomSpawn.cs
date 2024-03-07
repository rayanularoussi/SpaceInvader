using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject enemy;
    private float nextSpawnTime;
    public float minCooldown = 10f;
    public float maxCooldown = 30f;

    void Start()
    {
        nextSpawnTime = Time.time + Random.Range(minCooldown, maxCooldown);
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnObject();
            nextSpawnTime = Time.time + Random.Range(minCooldown, maxCooldown);
        }
    }

    void SpawnObject()
    {
        Instantiate(enemy);
    }
}
