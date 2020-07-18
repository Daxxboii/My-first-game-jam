using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_script : MonoBehaviour
{

    private GameObject[] all;

    //rewind stuff manager
    private GameObject player;
    private Rewind rewind;
    private Player_movement move;
    private GameObject rewind_button;

   

    void Start()
    {
        all = SceneManager.GetActiveScene().GetRootGameObjects();
        player = GameObject.FindWithTag("Player");
        rewind = player.GetComponent<Rewind>();
        move = player.GetComponent<Player_movement>();
        rewind_button = GameObject.FindWithTag("Rewind");
        rewind_button.SetActive(false);
    }



    void FixedUpdate()
    {
        //rewind 
        if (rewind.Is_rewinding)
        {
            move.enabled = false;
            rewind_button.SetActive(true);
        }
        else
        {
            move.enabled = true;
            rewind_button.SetActive(false);
        }
    }

   

}
