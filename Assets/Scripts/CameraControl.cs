using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float sensitivity;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        transform.Rotate(0, x * sensitivity * Time.deltaTime, 0, Space.World);
        transform.Rotate(-y * sensitivity * Time.deltaTime, 0, 0, Space.Self);
    }
}