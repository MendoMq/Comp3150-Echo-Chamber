using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public GameObject blackFade;
    public GameObject buttonNext;
    public GameObject player;


    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            blackFade.GetComponent<Fade>().startFading();
            buttonNext.SetActive(true);

            //Time.timeScale = 0f;
            
            player.GetComponent<Target>().health = 100000;
            /*player.GetComponent<MouseLookEcho>().enabled = false;
            player.GetComponent<PlayerAttack>().enabled = false;
            player.GetComponent<CharacterController>().enabled = false;
            player.GetComponent<PlayerMovement>().enabled = false;*/

            player.GetComponent<PlayerAttack>().end = true;
            

        }
    }

    public void NextLevel()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
