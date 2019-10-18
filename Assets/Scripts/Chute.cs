using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chute : MonoBehaviour
{
    public SpawnManager spawnManager;
    public GameManager gameManager;

    ScoreTracker scoreTracker;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        scoreTracker = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreTracker>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Debris"))
        {
            //activate effects
            if(audioSource != null && audioSource.clip != null)
            {
                audioSource.Play();
            }

            //decrement DebrisCount
            spawnManager.DebrisCount--;
            //add score
            scoreTracker.Score++;

            //disolve other object
            other.GetComponent<Disolve>().BeginDesolve();
        }
    }
}
