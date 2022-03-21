using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{

    Vector2 rotation = Vector2.zero;
	public float speed = 3;
    public GameObject VisionBubble;
    void Update()
    {
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
        if(Input.GetMouseButtonDown(0)){
            GameObject clone;
            clone = Instantiate(VisionBubble, transform.position, transform.rotation);
        }


        rotation.y += Input.GetAxis ("Mouse X");
		rotation.x += -Input.GetAxis ("Mouse Y");
		transform.eulerAngles = (Vector2)rotation * speed;
    }
}
