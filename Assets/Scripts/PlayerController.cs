using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public TriggerCheck groundCheck;
    public float jumpForce;
    public float fallMult;
    public float lowJumpMult;
    public float moveSpeed;


    Rigidbody rb;
    bool isMoving;
    float inputX;
    float inputY;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        if (inputX != 0 || inputY != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && groundCheck.isColliding)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            Vector3 force = new Vector3(inputX, 0, inputY) * moveSpeed;
            rb.AddForce(force * Time.deltaTime, ForceMode.Impulse);
        }
        if (rb.velocity.y < 0)
        {
            rb.AddForce(Vector3.up * Physics.gravity.y * (fallMult - 1) * Time.deltaTime, ForceMode.Impulse);
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * Physics.gravity.y * (lowJumpMult - 1) * Time.deltaTime, ForceMode.Impulse);
        }
    }
}