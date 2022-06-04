using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public GameObject fade;

    public GameObject player;


    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            fade.GetComponent<Fade>().startFading();
            

            //sets it so the player cannnot move and cannot die quickly
            player.GetComponent<Target>().health = 100000;
            player.GetComponent<MouseLookEcho>().enabled = false;
            player.GetComponent<PlayerAttack>().enabled = false;
            player.GetComponent<CharacterController>().enabled = false;
            player.GetComponent<PlayerMovement>().enabled = false;
            Cursor.lockState = CursorLockMode.None;

            player.GetComponent<PlayerAttack>().end = true;
            

        }
    }

    public void NextLevel()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
