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

    public Transform target;



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

        if (Time.time >= nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject Bullet = Instantiate(bullet, transform.position, Quaternion.identity);
            Physics.IgnoreCollision(Bullet.GetComponent<Collider>(), gunPos.parent.GetComponent<Collider>());
            Bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
            //Bullet.GetComponent<Bullet>().dmg = dmg;
        }
        
    }
}
