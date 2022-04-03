using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float dmg;

    void OnCollisionEnter(Collision collision)
    {
        Target target = collision.transform.GetComponent<Target>();
        if (target != null)
        {
            target.TakeDamage(dmg);
        }

        Destroy(gameObject);
    }

}
