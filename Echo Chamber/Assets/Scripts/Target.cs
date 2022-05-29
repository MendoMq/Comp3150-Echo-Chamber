using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{

    public float health = 50f;
    public GameObject deathEffect;
    public bool keepOnDeath;

    //for the item drops
    public GameObject speedBoost;
    public GameObject damageBoost;
    public GameObject shotgun;
    public GameObject smg;
    bool dead=false;
    public HealthBar healthBar;
    public bool drops = true;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(this.gameObject.tag == "Player")
        {
            healthBar.SetHealth(health);
        }
        if (health <= 0f && !keepOnDeath && !dead)
        {
            dead =true;
            Die();
        }
        if(health <= 0f && keepOnDeath){
            Debug.Log("Player Died");
            Die();
        }
    }

    void Die()
    {
        if(drops){
            //rnage is set for the number of item that can be dropped not the percent chance of drop rate
            int randomNo = Random.Range(1,16);
            if (randomNo == 1)
            {
                Instantiate(speedBoost, transform.position, Quaternion.identity);
            }else if (randomNo == 2)
            {
                Instantiate(damageBoost, transform.position, Quaternion.identity);
            }
            else if (randomNo == 3)
            {
                GameObject clone = Instantiate(smg, transform.position, Quaternion.identity);
                clone.GetComponent<GunScript>().upgradeID = 0;
            }
            else if (randomNo == 4)
            {
                GameObject clone = Instantiate(shotgun, transform.position, Quaternion.identity);
                clone.GetComponent<GunScript>().upgradeID = 1;
            }
        }
        
        if(gameObject.GetComponent<SupportAI>() != null)gameObject.GetComponent<SupportAI>().resetDebuf();

        if (gameObject.name == "Player")
        {
            SceneManager.LoadScene("IntroModelledLevel");
        }

        GameObject Effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
   
}
