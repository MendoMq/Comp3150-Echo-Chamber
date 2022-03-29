using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float dmg = 10f;
    public float range = 100f;
    public float fireRate = 5f;

    public Camera fpsCam;


    private float nextTimeToFire = 0f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(dmg);
            }
        }
    }
}
