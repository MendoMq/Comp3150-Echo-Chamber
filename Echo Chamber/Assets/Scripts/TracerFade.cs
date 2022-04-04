using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracerFade : MonoBehaviour
{
    Material material;
    float blend=0;
    public float blendMultiplier;
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        blend+=blendMultiplier*Time.deltaTime;
        material.SetFloat("_DistortionBlend",blend);
        if(blend>=1)Destroy(gameObject);
    }
}
