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

    int swapDir = 1;
    float timer = 0;
    float swapTime = 1f;

    float shootTimer = 1.5f;
    float shootTime = 4f;
    float waitTime = 2f;
    public GameObject SwarmProjectilePrefab;
    public GameObject EyeGameObject;
    public GameObject ShootParticle;


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

            if(Vector3.Distance(target.position, transform.position) < triggerLength){
                if(shootTimer>= shootTime){
                    Shoot();
                    ShootParticle.SetActive(true);
                    shootTimer = 0;
                    waitTime=2f;
                }
                if(shootTimer>= waitTime){
                    EyeGameObject.SetActive(true);
                    waitTime=6f;
                }
            }

            timer += Time.deltaTime;
            shootTimer += Time.deltaTime;
        }


    }

    void SetSwapTime(){
        swapTime = Random.Range(0.5f, 3f);
    }

    void Shoot(){
        GameObject clone = Instantiate(SwarmProjectilePrefab, transform.position, Quaternion.identity);
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
