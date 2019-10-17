using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chute : MonoBehaviour
{
    public SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Debris")
        {
            //activate effects


            //decrement DebrisCount
            spawnManager.DebrisCount--;

            //delete other object
            Destroy(other.gameObject);
        }
    }
}
