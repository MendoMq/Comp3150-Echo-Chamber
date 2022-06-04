using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSpawner : MonoBehaviour
{
    //this just sets the buble the spawns in the main menu
    public GameObject bubble;
    public float timer = 10f;

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0.0f)
        {
            timer = 10f;
            Spawn();
        }
    }


    public void Spawn()
    {
            Instantiate(bubble, transform.position, Quaternion.identity);
    }
}
