using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmAI : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float triggerLength = 4;
    public float dmg;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {

        if (Vector3.Distance(target.position, transform.position) < triggerLength)
        {
            transform.LookAt(target);
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, triggerLength);
    }

    

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Target target = collision.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(dmg);
                Debug.Log("hit");
            }
            Destroy(gameObject);
        }
        

        
    }
}
