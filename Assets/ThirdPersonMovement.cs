using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MovementController
{
    public LayerMask layer;
    public float rotSpeed = 10;
    RaycastHit hit;
    private void FixedUpdate()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);
        if(Physics.Raycast(ray, out hit, 500, layer))
        {
            if(hit.point != target)
            {
                target = hit.point;
            }
            
        }
        

    }

    private void Update()
    {
        Move();
    }
    public override void Move()
    {
        float moveSideways = Input.GetAxis("Horizontal");
        float moveForward = Input.GetAxis("Vertical");
        //Vector3 newPos = new Vector3(x, 0f, z);
        //transform.position += newPos* Time.deltaTime * speed;
        Quaternion rot = Quaternion.LookRotation(target - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * rotSpeed);
        transform.position = transform.position + Camera.main.transform.forward * (speed * moveForward) * Time.deltaTime;
        transform.position = transform.position + Camera.main.transform.right * (speed * moveSideways) * Time.deltaTime;
    }
}
