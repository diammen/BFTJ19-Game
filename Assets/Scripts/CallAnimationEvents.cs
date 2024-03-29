﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallAnimationEvents : MonoBehaviour
{
    PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void ThrowObject()
    {
        player.ThrowObject();
    }

    public void GrabObject()
    {
        player.GrabObject();
    }
}
