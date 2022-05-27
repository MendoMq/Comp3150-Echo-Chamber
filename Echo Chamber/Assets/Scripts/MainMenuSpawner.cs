using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSpawner : MonoBehaviour
{

    public GameObject bubble;
    public float timer = 5f;

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0.0f)
        {
            timer = 5f;
            Spawn();
        }
    }


    public void Spawn()
    {
        int randomNo = Random.Range(1, 5);
        if (randomNo == 3)
        {
            Instantiate(bubble, transform.position, Quaternion.identity);
        }

    }
}
