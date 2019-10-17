using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chute : MonoBehaviour
{
    public SpawnManager spawnManager;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Debris"))
        {
            //activate effects

            //decrement DebrisCount
            spawnManager.DebrisCount--;
            //add score
            gameManager.Score++;

            //delete other object
            Destroy(other.gameObject);
        }
    }
}
