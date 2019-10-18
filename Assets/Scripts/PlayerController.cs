using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public TriggerCheck groundCheck;
    public TriggerCheck pickupCheck;
    public GameObject hand;
    public Rigidbody currentPickup;
    public float jumpForce;
    public float fallMult;
    public float lowJumpMult;
    public float maxSpeed;
    public float acceleration;



    Rigidbody rb;
    bool isMoving;
    bool carryingItem;
    float inputX;
    float inputY;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
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

        if (Input.GetMouseButtonUp(0) && pickupCheck.isColliding && currentPickup == null && !carryingItem)
        {
            anim.SetTrigger("Grab");
        }
        else if (Input.GetMouseButtonUp(0) && currentPickup != null)
        {
            anim.SetTrigger("Throw");
        }
        else if (currentPickup == null && carryingItem)
        {
            carryingItem = false;
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            Vector3 camDir = new Vector3(inputX, 0, inputY);

            Vector3 force = Vector3.ProjectOnPlane(Camera.main.transform.right, Vector3.up).normalized * inputX + Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up).normalized * inputY;
            force = Vector3.ClampMagnitude(force * acceleration * Time.deltaTime, maxSpeed);
            rb.MovePosition(rb.position + force);
        }

        if (rb.velocity.y < 0)
        {
            rb.AddForce(Vector3.up * Physics.gravity.y * (fallMult - 1) * Time.deltaTime, ForceMode.VelocityChange);
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * Physics.gravity.y * (lowJumpMult - 1) * Time.deltaTime, ForceMode.VelocityChange);
        }
    }

    public void GrabObject()
    {
        currentPickup = pickupCheck.collidedWith.GetComponent<Rigidbody>();
        currentPickup.transform.position = hand.transform.position;
        currentPickup.transform.parent = hand.transform;
        currentPickup.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        currentPickup.isKinematic = true;
        currentPickup.detectCollisions = false;
        carryingItem = true;
    }

    public void ThrowObject()
    {
        currentPickup.isKinematic = false;
        currentPickup.detectCollisions = true;
        currentPickup.collisionDetectionMode = CollisionDetectionMode.Continuous;
        currentPickup.transform.parent = null;
        currentPickup.AddForce(Camera.main.transform.forward * 15, ForceMode.Impulse);
        currentPickup = null;
    }
}