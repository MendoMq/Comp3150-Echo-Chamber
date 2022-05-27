using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("l")){
            LoadLevel(1);
        }
    }

    public void LoadLevel(int n){
        Debug.Log("Loading Level "+n);
        if(n == 1)SceneManager.LoadSceneAsync("IntroModelledLevel");
    }

    public void Quit(){
        Debug.Log("Quitting");
        Application.Quit();
    }
}
