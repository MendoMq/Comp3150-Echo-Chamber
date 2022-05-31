using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : MonoBehaviour
{

    public PlayerMovement movement;

    public GameObject boosterParticle;



    public void Start()
    {
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Instantiate(boosterParticle, transform.position, transform.rotation);
            movement.booster = "SpeedBoost";
            Destroy(gameObject);
        }

    }


}
