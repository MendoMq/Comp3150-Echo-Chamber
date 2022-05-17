using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBooster : MonoBehaviour
{

    public PlayerAttack gunScript;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            gunScript.booster = gameObject.name;
            Destroy(gameObject);
        }

    }


}
