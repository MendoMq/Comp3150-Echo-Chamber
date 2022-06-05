using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneObject : MonoBehaviour
{
    
    public int levelIndex=1;
    public bool dead=false;
    public GameObject screenFade;
    public GameObject deathScreen;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("l")){
            LoadLevel(1);
        }
        if(Input.anyKey && dead){
            RestartLevel();
        }
    }

    public void LoadLevel(int n){
        Debug.Log("Loading Level "+n);
        levelIndex = n;
        if(n == 1)SceneManager.LoadSceneAsync("IntroModelledLevel");
        if(n == 0)SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void RestartLevel(){
        LoadLevel(levelIndex);
    }
    
    public void Died(){
        deathScreen.SetActive(true);
        dead=true;
    }

    public void Quit(){
        Debug.Log("Quitting");
        Application.Quit();
    }
}
