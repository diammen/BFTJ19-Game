using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnCollide : MonoBehaviour
{
    [SerializeField] private float requiredVelocity = 0.5f;

    private Rigidbody rb;
    private AudioSource audioSource;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(rb.velocity.magnitude >= requiredVelocity)
        {
            audioSource.Play();
        }
    }
}
