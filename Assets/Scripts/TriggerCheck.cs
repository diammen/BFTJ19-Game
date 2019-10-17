using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    public LayerMask layerMask;
    public GameObject collidedWith;
    public bool isColliding;
    public bool getObject;

    private void OnTriggerEnter(Collider other)
    {
        if (layerMask == (layerMask | 1 << other.gameObject.layer))
        {
            isColliding = true;
            if (getObject) collidedWith = other.gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (layerMask == (layerMask | 1 << other.gameObject.layer))
        {
            isColliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isColliding = false;
    }
}