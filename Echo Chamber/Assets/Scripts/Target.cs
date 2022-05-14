using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public float health = 50f;
    public GameObject deathEffect;
    public bool keepOnDeath;
    
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f && !keepOnDeath)
        {
            Die();
        }
        if(health <= 0f && keepOnDeath){
            Debug.Log("Player Died");
        }
    }

    void Die()
    {
        GameObject Effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
   
}
