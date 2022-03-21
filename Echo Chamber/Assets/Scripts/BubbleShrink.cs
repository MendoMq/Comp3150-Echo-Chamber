using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleShrink : MonoBehaviour
{

    Vector3 scaleChange;
    void Update()
    {
        scaleChange = new Vector3(1*Time.deltaTime,1*Time.deltaTime,1*Time.deltaTime);
        transform.localScale-=scaleChange;
        if(transform.localScale.x<=0)Destroy(gameObject);
    }
}
