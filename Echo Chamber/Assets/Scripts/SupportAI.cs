using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportAI : MonoBehaviour
{
    public Transform target;
    public float speed = 3;
    public float triggerLength = 8;
    public float effectLength = 4;
    public bool aiAgro = false;

    public PlayerAttack handPortal;
    public HeldPortal Handheld;
    public MouseLookEcho throwPortal;
    public PlayerMovement movement;

    public float slowingSpeed = 6;
    public float normalSpeed;

    public GameObject slowTagPrefab;
    GameObject slowTag;
    Vector3 startingTransform;
    public GameObject slowIndicator;
    public GameObject eyeObject;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        normalSpeed = movement.speed;
        slowTag = Instantiate(slowTagPrefab,transform.position,Quaternion.identity);
        //slowTag.transform.parent = gameObject.transform;
        slowTag.SetActive(false);
        startingTransform = transform.position;
        slowIndicator.SetActive(false);
    }


    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) < triggerLength && aiAgro == false)
        {
            aiAgro = true;
        }
        if (aiAgro)
        {
            if (Vector3.Distance(target.position, transform.position) <= effectLength)
            {
                movement.speed = slowingSpeed;
                handPortal.disabled = true;
                throwPortal.disabled = true;
                Handheld.disabled = true;

                slowTag.SetActive(true);
                LineRenderer line = slowTag.GetComponent<LineRenderer>();
                line.SetPosition(0,eyeObject.transform.position-startingTransform);
                line.SetPosition(1,(target.transform.position-transform.position)+(transform.position-startingTransform));
                slowIndicator.SetActive(true);

            }
            else
            {
                movement.speed = normalSpeed;
                handPortal.disabled = false;
                throwPortal.disabled = false;
                Handheld.disabled = false;

                slowTag.SetActive(false);
                slowIndicator.SetActive(false);
            }
            if (Vector3.Distance(target.position, transform.position) >= 5)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else
            {
                transform.position += new Vector3(-transform.forward.x * speed * Time.deltaTime, 0, -transform.forward.z * speed * Time.deltaTime);
                transform.localPosition += transform.right * 1 * speed * 1.5f * Time.deltaTime;
            }
            transform.LookAt(target);
        }
    }

    public void resetDebuf(){
        movement.speed = normalSpeed;
        handPortal.disabled = false;
        throwPortal.disabled = false;
        Handheld.disabled = false;
        slowTag.SetActive(false);
        slowIndicator.SetActive(false);
    }



    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, triggerLength);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, effectLength);
    }
}
