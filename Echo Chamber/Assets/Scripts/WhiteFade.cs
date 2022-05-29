using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhiteFade : MonoBehaviour
{
    int maxValue = 1;
    float alpha;
    public float speed;
    bool fading = false;
    Image image;
    
    
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    public void startFading(){
        fading = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(fading){
            image.color = new Color(image.color.r,image.color.g,image.color.b,alpha);
            if(alpha < maxValue){
                alpha += Time.deltaTime * speed;
            }else{
                alpha = maxValue;
            }
        }
    }
}
