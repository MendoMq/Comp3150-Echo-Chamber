using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldPortal : MonoBehaviour
{

    public float maxScale = 0.2f;
    public float minScale = 0.01f;
    public PlayerAttack attackScript;
    public MeshRenderer outline;
    public GameObject particles;
    public float scaleChange = -0.1f;

    bool weaponOn=true;

    // Update is called once per frame
    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        outline.enabled = false;
        particles.GetComponent<Renderer>().enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            weaponOn = false;
            if(transform.localScale.x < maxScale)
            {
                gameObject.GetComponent<Renderer>().enabled = true;
                outline.enabled = true;
                particles.GetComponent<Renderer>().enabled = true;

                transform.localScale += new Vector3(scaleChange * Time.deltaTime, scaleChange * Time.deltaTime, scaleChange * Time.deltaTime);
                particles.transform.localScale = transform.localScale;
            }
        }
        else
        {
            if(transform.localScale.x <= minScale)
            {
                if(weaponOn == false) attackScript.ChangeToPistol();
                weaponOn = true;
                gameObject.GetComponent<Renderer>().enabled=false;
                outline.enabled = false;
                particles.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                transform.localScale -= new Vector3(scaleChange * Time.deltaTime, scaleChange * Time.deltaTime, scaleChange * Time.deltaTime);
                particles.transform.localScale = transform.localScale;
            }
            
        }
    }
}
