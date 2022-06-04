using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public SceneObject sceneObject;
    public void setActive()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            sceneObject.LoadLevel(1);
        }
        if (Input.GetKeyDown("x"))
        {
            sceneObject.LoadLevel(2);
        }
    }
}
