using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //logic
    public float triggerLength = 1;
    public float speed;

    public GameObject bullet;
    public Transform gunPos;
    public float bulletSpeed = 30f;
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;
    public float dmg = 10f;

    private Transform target;


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    void Update()
    {
        gunPos = gunPos.GetComponent<Transform>();
        
        //check for player
        if (Vector3.Distance(target.position, transform.position) < triggerLength)
        {
            shoot();
            
        }
    }

        void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, triggerLength);
    }

    void shoot()
    {
        transform.LookAt(target);


        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject Bullet = Instantiate(bullet);
            Physics.IgnoreCollision(Bullet.GetComponent<Collider>(), gunPos.parent.GetComponent<Collider>());
            Bullet.transform.position = gunPos.position;
            Vector3 rotation = Bullet.transform.rotation.eulerAngles;
            Bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
            Bullet.GetComponent<Rigidbody>().AddForce(gunPos.forward * bulletSpeed, ForceMode.Impulse);
            Bullet.GetComponent<Bullet>().dmg = dmg;
        }
       


    }
}
