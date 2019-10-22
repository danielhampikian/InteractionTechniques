using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    
    public bool animatingTracker;
    Animator anim;
    RaycastHit hit;
    public LayerMask layer;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.white);
        if (Physics.Raycast(ray, out hit, 500, layer))
        {
            if (hit.transform.gameObject.name == "Cylinder")
            {
                anim = hit.transform.gameObject.GetComponent<Animator>();
                hit.transform.gameObject.GetComponent<Renderer>().material.SetColor("_Color",Color.green);

                animatingTracker = !animatingTracker;
                anim.SetBool("rotating", animatingTracker);

            }

        }
        else
        {
            Debug.Log("Exited layer");
        }
    }
}
