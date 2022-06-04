using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public PlayerAttack gunScript;
    public int upgradeID;

    public void Start()
    {
        gunScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
    }

    void OnTriggerEnter(Collider coll)
    {
        //checking the playre guns base on the gun they pickup
        if (coll.gameObject.tag == "Player")
        {
            if(upgradeID == 0){
                gunScript.ChangeToSmg();
            } else if(upgradeID == 1){
                gunScript.ChangeToShotgun();
            }
            gunScript.ammo = 100;
            Destroy(gameObject);
        }
        
    }
}
