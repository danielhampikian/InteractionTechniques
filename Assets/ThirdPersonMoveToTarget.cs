using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMoveToTarget : MovementController
{
    public LayerMask layer;
    public float rotSpeed = 10;
    RaycastHit hit;
    bool notAtDestination;
    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);
        if (Physics.Raycast(ray, out hit, 500, layer))
        {
            if (hit.point != target)
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
        
        if (Input.GetMouseButtonDown(0) || notAtDestination)
        {
            notAtDestination = true;
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * speed);
            if (Vector3.Distance(transform.position, target) < .1)
            {
                notAtDestination = false;
            }
        }
        Quaternion rot = Quaternion.LookRotation(target - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * rotSpeed);
       
    }
}
