using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public PlayerAttack gunScript;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            gunScript.gunName = gameObject.name;
            gunScript.ammo = 100;
            Destroy(gameObject);
        }
        
    }
}
