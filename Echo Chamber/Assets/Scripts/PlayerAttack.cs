using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float dmg = 10f;
    public float range = 100f;
    public float fireRate = 5f;
    private float nextTimeToFire = 0f;


    public Camera fpsCam;

    public float swingRate = 5f;
    private float nextTimeToSwing = 0f;
    public float attackRange = 30f;

    public Transform attackPoint;
    public LayerMask enemyLayers;
    public GameObject BulletTracer;
    public GameObject gun;
    public GameObject HitEffect;
    public GameObject MissEffect;

    public string gunName = "";

    public int ammo = 100;

    //shotgun var
    public int pelletCount = 5;
    [Range(0.0f, 1.0f)]
    public float verticaleSpread = 10f;
    [Range(0.0f, 1.0f)]
    public float horizontalSpread = 10f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Fire();
        } 
        

        if (Input.GetButtonDown("Fire2") && Time.time >= nextTimeToSwing)
        {
            nextTimeToSwing = Time.time + 1f / swingRate;
            Swing();
        }

        if (ammo == 0)
        {
            gunName = "";
        }

    }


    void Fire()
    {
        if (gunName == "")
        {
            Shoot();
        }
        else if (gunName == "Shotgun") 
        {
            ShotgunCal();
        } else if (gunName == "SMG") 
        { 
            SMG();
        }

    }

    void Shoot()
    {
        RaycastHit hit;
        dmg = 10f;
        fireRate = 5f;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {


            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(dmg);
                GameObject HitClone = Instantiate(HitEffect, hit.point, Quaternion.identity);
            }else{
                GameObject MissClone = Instantiate(MissEffect, hit.point, Quaternion.identity);
            }

            gun.GetComponent<Animation>().Play("GunShoot");
            GameObject clone = Instantiate(BulletTracer, gun.transform.position, Quaternion.identity);
            LineRenderer line = clone.GetComponent<LineRenderer>();
            line.SetPosition(1,hit.point-gun.transform.position);
        }
    }

    void SMG()
    {
        if (ammo > 0)
        {
            ammo -= 5;
            RaycastHit hit;
            dmg = 5f;
            fireRate = 10f;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {

                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(dmg);
                    GameObject HitClone = Instantiate(HitEffect, hit.point, Quaternion.identity);
                }
                else
                {
                    GameObject MissClone = Instantiate(MissEffect, hit.point, Quaternion.identity);
                }

                gun.GetComponent<Animation>().Play("GunShoot");
                GameObject clone = Instantiate(BulletTracer, gun.transform.position, Quaternion.identity);
                LineRenderer line = clone.GetComponent<LineRenderer>();
                line.SetPosition(1, hit.point - gun.transform.position);
            }
        }
        
    }

    void ShotgunCal()
    {
        fireRate = 3f;
        dmg = 15f;
        ammo -= 20;

        float spreadX = 0.0f;
        float spreadY = 0.0f;
        float rad = 0.0f;

        for (int i = 0; i < pelletCount; i++)
        {
            rad = Random.Range(0.0f, 360.0f) * Mathf.Rad2Deg;
            spreadX = Random.Range(0.0f, horizontalSpread / 2.0f) * Mathf.Cos(rad);
            spreadY = Random.Range(0.0f, verticaleSpread / 2.0f) * Mathf.Sin(rad);

            Vector3 deviation = new Vector3(spreadX, spreadY, 0.0f);
            ShotgunFire(deviation);

        }
    }
    void ShotgunFire(Vector3 deviation) { 
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, deviation + fpsCam.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(dmg);
                GameObject HitClone = Instantiate(HitEffect, hit.point, Quaternion.identity);
            }
            else
            {
                GameObject MissClone = Instantiate(MissEffect, hit.point, Quaternion.identity);
            }
            gun.GetComponent<Animation>().Play("GunShoot");
            GameObject clone = Instantiate(BulletTracer, gun.transform.position, Quaternion.identity);
            LineRenderer line = clone.GetComponent<LineRenderer>();
            line.SetPosition(1, hit.point - gun.transform.position);
        }
    }


    void Swing()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);
            Target target = enemy.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(dmg);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
