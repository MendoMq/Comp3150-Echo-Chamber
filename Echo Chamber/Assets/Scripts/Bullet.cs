using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float dmg;

    void OnCollisionEnter(Collision collision)
    {
        //if the object hit has a target script, then that target takes damage
        Target target = collision.transform.GetComponent<Target>();
        if (target != null)
        {
            target.TakeDamage(dmg);
        }

        Destroy(gameObject);
    }

}
