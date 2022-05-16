using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float dmg = 10f;
    public float range = 100f;
    public float fireRate = 5f;
    private float nextTimeToFire = 0f;


    public Camera fpsCam;

    public float swingRate = 5f;
    public float attackRange = 30f;

    public Transform attackPoint;
    public LayerMask enemyLayers;
    public GameObject BulletTracer;
    public GameObject gun;
    public GameObject HitEffect;
    public GameObject MissEffect;

    public Color pistolColor;
    public Color smgColor;
    public Color shotgunColor;
    public Color portalColor;

    public GameObject pistolParticle;
    public GameObject smgParticle;
    public GameObject shotgunParticle;
    public GameObject portalParticle;

    public string gunName = "Pistol";

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
        
        if (Input.GetButtonDown("Fire2"))
        {
            ChangeToPortal();
        }

        if (ammo <= 0 && gunName!="Pistol")
        {
            ChangeToPistol();
        }

        if (gunName != "Portal")
        {
            if (Input.GetKeyDown("1"))
            {
                ChangeToPistol();
            }

            if (Input.GetKeyDown("2"))
            {
                if (ammo > 0) ChangeToSmg();
            }
            if (Input.GetKeyDown("3"))
            {
                if (ammo > 0) ChangeToShotgun();
            }
        }
        
    }

    public void ChangeToPistol(){
        dmg = 10f;
        fireRate = 3f;
        
        Material mat = gun.GetComponent<Renderer>().material;
        mat.color = pistolColor;
        gunName = "Pistol";
        GameObject clone = Instantiate(pistolParticle, gun.transform.position, Quaternion.identity);
        clone.transform.parent = gun.transform;
    }
    
    void ChangeToSmg(){
        dmg = 5f;
        fireRate = 8f;

        Material mat = gun.GetComponent<Renderer>().material;
        mat.color = smgColor;
        gunName = "SMG";
        GameObject clone = Instantiate(smgParticle, gun.transform.position, Quaternion.identity);
        clone.transform.parent = gun.transform;
    }
    void ChangeToShotgun(){
        fireRate = 2f;
        dmg = 8f;

        Material mat = gun.GetComponent<Renderer>().material;
        mat.color = shotgunColor;
        gunName = "Shotgun";
        GameObject clone = Instantiate(shotgunParticle, gun.transform.position, Quaternion.identity);
        clone.transform.parent = gun.transform;
    }

    void ChangeToPortal(){
        if (gunName != "Portal"){
            Material mat = gun.GetComponent<Renderer>().material;
            mat.color = portalColor;
            gunName = "Portal";
            GameObject clone = Instantiate(portalParticle, gun.transform.position, Quaternion.identity);
            clone.transform.parent = gun.transform;
        }
    }


    void Fire()
    {
        if (gunName == "Pistol")
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
        float spreadX = 0.0f;
        float spreadY = 0.0f;
        float rad = 0.0f;

        rad = Random.Range(0.0f, 360.0f) * Mathf.Rad2Deg;
        spreadX = Random.Range(0.0f, horizontalSpread / 4.0f) * Mathf.Cos(rad);
        spreadY = Random.Range(0.0f, verticaleSpread / 4.0f) * Mathf.Sin(rad);

        Vector3 deviation = new Vector3(spreadX, spreadY, 0.0f);

        if (ammo > 0)
        {
            ammo -= 5;
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
        
    }

    void ShotgunCal()
    {
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

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
