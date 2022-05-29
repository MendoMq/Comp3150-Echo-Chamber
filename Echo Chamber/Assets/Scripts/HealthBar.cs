using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public float sliderChange;
    float currentHealth;
    float visualHealth;

    void Start(){
        slider.maxValue = 50;
        slider.value = 50;
        currentHealth = 50;
        visualHealth = currentHealth;
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
        currentHealth = health;
        visualHealth = currentHealth;
    }

    public void SetHealth(float health)
    {
        currentHealth = health;
    }

    void Update(){
        if(currentHealth < visualHealth){
            visualHealth -= sliderChange * Time.deltaTime;
        }else if(currentHealth > visualHealth){
            visualHealth += sliderChange * Time.deltaTime;
        }

        slider.value = visualHealth;
    }
}
