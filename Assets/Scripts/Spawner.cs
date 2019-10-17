using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] spawnPool;
    public float spawnRate;

    private float spawnTimer;
    private SpawnManager spawnManager;

    // Use this for initialization
    void Start()
    {
        spawnManager = GetComponentInParent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer <= 0)
        {
            Instantiate(spawnPool[Random.Range(0, spawnPool.Length)], transform.position + (Random.insideUnitSphere * 0.2f), Random.rotation);
            spawnTimer += spawnRate;
            spawnManager.DebrisCount++;
        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }
    }
}
