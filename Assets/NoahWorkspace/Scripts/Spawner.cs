using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] spawnPool;
    public float spawnRate;

    private float spawnTimer;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer <= 0)
        {
            Instantiate(spawnPool[Random.Range(0, spawnPool.Length)], transform.position + (Random.insideUnitSphere * 0.2f), Random.rotation);
            spawnTimer = spawnRate;
        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }
    }
}
