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
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (audioSource != null && audioSource.clip != null && rb.velocity.magnitude >= requiredVelocity)
        {
            audioSource.Play();
        }
    }
}
