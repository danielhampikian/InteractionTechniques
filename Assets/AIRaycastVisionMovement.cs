using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRaycastVisionMovement : MovementController
{
    public Transform player;
    public LayerMask layer;
    public Vector3 direction;
    RaycastHit hit;
    public float rotSpeed = 2f;
    public float visibleDistance = 10f;
    public float visibleAngle = 30f;
    public float shootDistance = 5f;

    void Update()
    {
        MoveToRaycast();
        Ray ray = new Ray(transform.position, direction);
        Debug.DrawRay(ray.origin, ray.direction * visibleDistance, Color.red);
        if (Physics.Raycast(ray, out hit, visibleDistance, layer))
        {
            if (hit.point != target)
            {
                target = hit.point;
            }

        }
    }
    public override void Move()
    {
        target = player.position;
        direction = player.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);
        if (direction.magnitude < visibleDistance && angle < visibleAngle)
        {
            direction.y = 0;
            transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(direction),
                Time.deltaTime * rotSpeed);
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * speed);

        }
    }
    public void MoveToRaycast()
    {
        //target = player.position;
        direction = target - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);
        if (angle < visibleAngle)
        {
            direction.y = 0;
            transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(direction),
                Time.deltaTime * rotSpeed);
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * speed);
        }
    }
}
