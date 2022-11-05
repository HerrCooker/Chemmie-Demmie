using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{

    public float health, maxHealth;
    public HealthBar healthBar;
    public void TakeDamage()
    {
        // Use your own damage handling code, or this example one.
        health -= Mathf.Min(Random.value, health / 4f);
        healthBar.UpdateHealthBar();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Example so we can test the Health Bar functionality
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage();
        }
    }
}
