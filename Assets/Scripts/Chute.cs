using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chute : MonoBehaviour
{
    public SpawnManager spawnManager;
    public GameManager gameManager;

    ScoreTracker scoreTracker;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        scoreTracker = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreTracker>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Debris"))
        {
            //activate effects

            //decrement DebrisCount
            spawnManager.DebrisCount--;
            //add score
            scoreTracker.Score++;

            //delete other object
            Destroy(other.gameObject);
        }
    }
}
