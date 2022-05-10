using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmAI : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float triggerLength = 4;
    public float minDistance = 2;
    public float dmg;
    public bool aiAgro = false;
    public GameObject explosionEffect;

    int swapDir = 1;
    float timer = 0;
    float swapTime = 1f;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {

        if (Vector3.Distance(target.position, transform.position) < triggerLength && aiAgro == false)
        {
            aiAgro = true;
            SetSwapTime();
        }

        if(aiAgro){
            if(Vector3.Distance(target.position, transform.position) >= minDistance){
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }else{
                transform.position += new Vector3 (-transform.forward.x * speed * Time.deltaTime,0,-transform.forward.z * speed * Time.deltaTime);
                transform.localPosition += transform.right * swapDir * speed * 1.5f * Time.deltaTime;
            }
            transform.LookAt(target);

            if(timer >= swapTime){
                swapDir = -swapDir;
                SetSwapTime();
                timer = 0;
            }

            timer += Time.deltaTime;

        }


    }

    void SetSwapTime(){
        swapTime = Random.Range(0.5f, 3f);
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
