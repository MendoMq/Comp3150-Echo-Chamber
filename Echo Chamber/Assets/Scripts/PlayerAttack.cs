using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float dmg = 10f;
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
    public Transform tracerPoint;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }

        if (Input.GetButtonDown("Fire2") && Time.time >= nextTimeToSwing)
        {
            nextTimeToSwing = Time.time + 1f / swingRate;
            Swing();
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

            GameObject clone = Instantiate(BulletTracer, tracerPoint.position, Quaternion.identity);
            LineRenderer line = clone.GetComponent<LineRenderer>();
            line.SetPosition(1,hit.point-tracerPoint.position);
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
