using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookEcho : MonoBehaviour
{
    

    Vector2 rotation = Vector2.zero;
	public float speed = 3;
    public GameObject ProbePrefab;
    public GameObject AntiPrefab;
    public float throwThrust;
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        /*
        if(Input.GetKey("w")){
            transform.Translate(Vector3.forward * Time.deltaTime * 4);
        }
        if(Input.GetKey("a")){
            transform.Translate(Vector3.left * Time.deltaTime * 4);
        }
        if(Input.GetKey("s")){
            transform.Translate(Vector3.back * Time.deltaTime * 4);
        }
        if(Input.GetKey("d")){
            transform.Translate(Vector3.right * Time.deltaTime * 4);
        }
        if(Input.GetKey("space")){
            transform.Translate(Vector3.up * Time.deltaTime * 4);
        }
        if(Input.GetKey("left ctrl")){
            transform.Translate(Vector3.down * Time.deltaTime * 4);
        }
        */
        if (Input.GetMouseButtonDown(1)){
            GameObject clone;
            clone = Instantiate(ProbePrefab, transform.position+(transform.forward*1f), Quaternion.identity);
            clone.GetComponent<Rigidbody>().AddForce(transform.up * throwThrust*0.75f, ForceMode.Impulse);
            clone.GetComponent<Rigidbody>().AddForce(transform.forward * throwThrust*1.5f, ForceMode.Impulse);
        }

        if (Input.GetKeyDown("q"))
        {
            GameObject clone;
            clone = Instantiate(AntiPrefab, transform.position + (transform.forward * 1f), Quaternion.identity);
            clone.GetComponent<Rigidbody>().AddForce(transform.up * throwThrust * 0.75f, ForceMode.Impulse);
            clone.GetComponent<Rigidbody>().AddForce(transform.forward * throwThrust * 1.5f, ForceMode.Impulse);
        }


        rotation.y += Input.GetAxis ("Mouse X");
		rotation.x += -Input.GetAxis ("Mouse Y");
        rotation.x = Mathf.Clamp(rotation.x, -30f, 30f);
		transform.eulerAngles = (Vector2)rotation * speed;
    }
}
