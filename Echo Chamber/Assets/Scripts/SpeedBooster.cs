using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : MonoBehaviour
{

    public PlayerMovement movement;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            movement.booster = gameObject.name;
            Destroy(gameObject);
        }

    }


}
