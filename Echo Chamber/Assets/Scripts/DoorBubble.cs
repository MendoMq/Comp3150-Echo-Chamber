using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBubble : MonoBehaviour
{
    public float maxScale;
    public float changeScale;
    public GameObject door;
    public bool expanding;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void expand(){
        door.GetComponent<Collider>().enabled = false;
        expanding=true;
    }

    // Update is called once per frame
    void Update()
    {
        if(expanding){
            transform.localScale += new Vector3(changeScale*Time.deltaTime ,changeScale*Time.deltaTime ,changeScale*Time.deltaTime);
            if(transform.localScale.x > maxScale){
                Destroy(door);
                Destroy(gameObject);
            }
        }
        
    }
}
