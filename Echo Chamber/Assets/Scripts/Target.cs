using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public float health = 50f;
    public GameObject explosionEffect;
    
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject Explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
   
}
