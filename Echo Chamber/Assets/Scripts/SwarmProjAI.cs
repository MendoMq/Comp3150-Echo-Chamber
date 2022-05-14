using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmProjAI : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float dmg;
    public float minDistance=1f;
    float timer = 0;
    float explTime = 3f;
    public GameObject explosionPrefab;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        transform.LookAt(target);

        if(timer >= explTime){
            Explode();
        }

        if (Vector3.Distance(target.position, transform.position) <= minDistance){
            target.gameObject.GetComponent<Target>().TakeDamage(dmg);
            Explode();
        }

        timer += Time.deltaTime;
    }

    void Explode(){
        GameObject clone = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}