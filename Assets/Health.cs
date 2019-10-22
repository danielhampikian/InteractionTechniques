using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Text healthBox;
    public float health = 100;
    private void Start()
    {
        LoseHealth(0);
    }
    public void LoseHealth(float damage)
    {
        health -= damage;
        healthBox.text = "Remaining Health: " + health.ToString();
    }

}
