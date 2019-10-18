using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int ActiveSpawners
    {
        get { return activeSpawners; }
    }

    public int DebrisCount
    {
        get
        {
            return debrisCount;
        }
        set
        {
            debrisCount = value;

            if (debrisCount >= maxDebris)
            {
                Lose();
            }
        }
    }

    [SerializeField] private float activationTimer = 4;
    [SerializeField] private float activationTimeBase = 30;
    [SerializeField] private float activationTimeCurrent;
    [SerializeField] private float activationTimeMultiplier = 1;
    [SerializeField] private int activeSpawners = 0;
    private Spawner[] spawners;

    [SerializeField] private int maxDebris = 40;
    [SerializeField] private int debrisCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        activationTimeCurrent = activationTimeBase;
        spawners = GetComponentsInChildren<Spawner>(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (ActiveSpawners < spawners.Length)
        {
            if (activationTimer <= 0)
            {
                spawners[ActiveSpawners].enabled = true;
                activeSpawners++;
                activationTimer += activationTimeCurrent;
                activationTimeCurrent += activationTimeBase * activeSpawners * activationTimeMultiplier;
            }
            activationTimer -= Time.deltaTime;
        }
    }

    private void Lose()
    {
        
    }
}
