using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPaint : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.tag == "paint")
        {

            Debug.Log("Collided with" + collision.gameObject.name);
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            foreach (var p in collision.contacts)
            {
                sphere.transform.position = p.point;
                sphere.gameObject.GetComponent<Renderer>().material.color = Color.red;
                sphere.transform.localScale *= .5f;
            }
        }
        else if( collision.gameObject.name == "Enemy")
        {
            GetComponent<ParticleSystem>().Play();
            GetComponent<Health>().LoseHealth(10);
        }
        else if (collision.gameObject.name == "Freind")
        {
            GetComponent<Health>().LoseHealth(-10);
        }
    }
}
