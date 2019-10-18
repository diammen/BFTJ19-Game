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

    PlayerController player;
    CameraControl cameraControl;
    GameManager gameManager;

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
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        cameraControl = Camera.main.GetComponent<CameraControl>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
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
                activationTimeCurrent = activationTimeBase * (float)Math.Pow(activationTimeMultiplier, activeSpawners);
            }
            activationTimer -= Time.deltaTime;
        }
    }

    private void Lose()
    {
        foreach(var spawner in spawners)
        {
            spawner.enabled = false;
        }
        activeSpawners = 0;

        player.enabled = false;
        cameraControl.enabled = false;

        StartCoroutine(WaitToTransition(3));
    }

    private IEnumerator WaitToTransition(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameManager.GoToMainMenu();
    }
}
