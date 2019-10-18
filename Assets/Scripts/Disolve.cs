using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disolve : MonoBehaviour
{
    [SerializeField] private float disolveTime = 3;

    private Material mat;
    private bool disolving = false;

    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        mat =  GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if(disolving == true)
        {
            timer += Time.deltaTime;
            mat.SetFloat("Dissolve", timer / disolveTime);
            if(timer >= disolveTime)
            {
                Destroy(gameObject);
            }
        }
    }

    public void BeginDesolve()
    {
        disolving = true;
        gameObject.layer = 13;
    }
}
