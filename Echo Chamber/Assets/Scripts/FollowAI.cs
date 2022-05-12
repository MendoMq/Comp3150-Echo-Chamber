using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAI : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float triggerLength ;
    public float minDistance;
    public float dmg;
    public bool aiAgro = false;
    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) < triggerLength && aiAgro == false)
        {
            aiAgro = true;
        }
        if (aiAgro)
        {
            if (Vector3.Distance(target.position, transform.position) <= minDistance)
            {
                GameObject Explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

                transform.position -= new Vector3(-transform.forward.x * speed * Time.deltaTime, 0, -transform.forward.z * speed * Time.deltaTime);
            transform.LookAt(target);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, triggerLength);
    }
}
