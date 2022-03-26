using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleShrink : MonoBehaviour
{

    Vector3 scaleChange;
    float timer=0f;
    public float growTime=1f;
    public float growSpeed=10f;
    public float shrinkSpeed=1.5f;
    bool growing=true;
    void Update()
    	{
	timer+=Time.deltaTime;
        if(timer>=growTime)growing=false;
	if(growing){
		scaleChange = new Vector3(growSpeed*Time.deltaTime,growSpeed*Time.deltaTime,growSpeed*Time.deltaTime);
	}else{
		scaleChange = new Vector3(-shrinkSpeed*Time.deltaTime,-shrinkSpeed*Time.deltaTime,-shrinkSpeed*Time.deltaTime);
	}
        transform.localScale+=scaleChange;

    
        if(transform.localScale.x<=0)Destroy(gameObject);
    }
}
