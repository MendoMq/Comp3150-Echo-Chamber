using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneObject : MonoBehaviour
{
    
    public int levelIndex=1;
    public GameObject screenFade;
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("l")){
            LoadLevel(1);
        }
    }

    public void LoadLevel(int n){
        Debug.Log("Loading Level "+n);
        levelIndex = n;
        if(n == 1)SceneManager.LoadSceneAsync("IntroModelledLevel");
        if(n == 0)SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
        if(n == 2) SceneManager.LoadSceneAsync("MainMenuScene");
    }

    public void RestartLevel(){
        LoadLevel(levelIndex);
    }

    public void Quit(){
        Debug.Log("Quitting");
        Application.Quit();
    }
}
