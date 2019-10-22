using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    Rigidbody rb;
    public float speed = 4f;
    public float rotationSpeed = 4f;

    private void Start()
    {
        player = new GameObject();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 lookDirection = player.transform.position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection),
            Time.deltaTime * rotationSpeed);
            transform.position += speed * Time.deltaTime * transform.forward;
        }
    }

    void MoveAgent(Vector3 lookDirection)
    {
        /*transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection),
                Time.deltaTime * rotationSpeed);
        rb.MovePosition(rb.position + transform.forward * speed * Time.deltaTime);*/
            rb.MoveRotation(rb.rotation);
    }
}
