﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    [SerializeField] TextMeshProUGUI loseText;

    [SerializeField] private float activationTimer = 4;
    [SerializeField] private float activationTime = 30;
    [SerializeField] private int activeSpawners = 0;
    private Spawner[] spawners;

    [SerializeField] private int maxDebris = 40;
    [SerializeField] private int debrisCount = 0;

    // Start is called before the first frame update
    void Start()
    {
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
                activationTimer += activationTime;
            }
            activationTimer -= Time.deltaTime;
        }
    }

    private void Lose()
    {
        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i].enabled = false;
            activeSpawners = 0;
        }
        player.enabled = false;
        cameraControl.enabled = false;
        loseText.enabled = true;
        StartCoroutine(CountdownToSceneTransition(3));
    }

    private IEnumerator CountdownToSceneTransition(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameManager.GoToMainMenu();
    }
}
