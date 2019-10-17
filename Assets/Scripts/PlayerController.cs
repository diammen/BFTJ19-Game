using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public TriggerCheck groundCheck;
    public TriggerCheck pickupCheck;
    public GameObject hand;
    public Rigidbody currentPickup;
    public float jumpForce;
    public float fallMult;
    public float lowJumpMult;
    public float moveSpeed;
    public float drag;



    Rigidbody rb;
    bool isMoving;
    float inputX;
    float inputY;
    [SerializeField]
    float speed;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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

        if (Input.GetMouseButtonUp(0) && pickupCheck.isColliding && currentPickup == null)
        {
            currentPickup = pickupCheck.collidedWith.GetComponent<Rigidbody>();
            currentPickup.transform.position = hand.transform.position;
            currentPickup.transform.parent = hand.transform;
            currentPickup.isKinematic = true;
        }
        else if (Input.GetMouseButtonUp(0) && currentPickup != null)
        {
            currentPickup.isKinematic = false;
            currentPickup.transform.parent = null;                                          
            currentPickup = null;
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            Vector3 camDir = new Vector3(inputX, 0, inputY);

            Vector3 force = Vector3.ProjectOnPlane(Camera.main.transform.right, Vector3.up).normalized * inputX + Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up).normalized * inputY;
            force = Vector3.ClampMagnitude(force * moveSpeed, moveSpeed) * Time.deltaTime;
            rb.AddForce(force, ForceMode.VelocityChange);
        }

        if (rb.velocity.y < 0)
        {
            rb.AddForce(Vector3.up * Physics.gravity.y * (fallMult - 1) * Time.deltaTime, ForceMode.VelocityChange);
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * Physics.gravity.y * (lowJumpMult - 1) * Time.deltaTime, ForceMode.VelocityChange);
        }
        rb.velocity *= drag;

        speed = rb.velocity.magnitude;
    }
}