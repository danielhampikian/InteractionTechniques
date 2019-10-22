using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Vector3 target;
    public float speed = 5;

    public virtual void Move()
    {
        Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
    }
}
