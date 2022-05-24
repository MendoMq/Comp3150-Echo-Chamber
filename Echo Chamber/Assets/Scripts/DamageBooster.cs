using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBooster : MonoBehaviour
{

    public PlayerAttack gunScript;


    public void Start()
    {
        gunScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            gunScript.booster = "DamageBoost";
            Destroy(gameObject);
        }

    }


}
