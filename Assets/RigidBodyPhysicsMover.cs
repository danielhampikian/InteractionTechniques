using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyPhysicsMover : MonoBehaviour
{
    //Arrow/wasd move variables:
    public Rigidbody rb;
    public float speed = 1;

    //Mouse/trackpad look variables:
    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

    private void Start()
    {
        //Arrow/wasd move code:
        rb = GetComponent<Rigidbody>();

        //Mouse/trackpad look code:
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;

    }

    private void Update()
    {
        //Arrow/wasd move code:
        float moveForward = Input.GetAxis("Vertical");
        float moveSideways = Input.GetAxis("Horizontal");

        //Mouse/trackpad look code:
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;

        //Combine them to move in look direction

        rb.MovePosition(transform.position + Camera.main.transform.forward * (speed * moveForward) * Time.deltaTime);
        Quaternion rot = Quaternion.Euler(transform.position + Camera.main.transform.right * (speed * moveSideways) * Time.deltaTime);
        rb.MoveRotation(rot);
    }
}
