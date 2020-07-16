using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_script : MonoBehaviour
{
    
    public GameObject[] all;

    //rewind stuff manager
    private GameObject player;
    private Rewind rewind;
    private Player_movement move;

    bool Game_Ended = false;

    void Start()
    {
      all = SceneManager.GetActiveScene().GetRootGameObjects();
        player = GameObject.FindWithTag("Player");
        rewind = player.GetComponent<Rewind>();
        move = player.GetComponent<Player_movement>();
    }

    

    void Update()
    {
        //rewind 
        if (rewind.Is_rewinding)
        {
            move.enabled = false;
        }
        else
        {
            move.enabled = true;
        }
    }

    //End_Game or Repawn
    public void End_Game()
    {
        if (Game_Ended == false)
        {
          // later to end the game      Game_Ended = true;
            Restart();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
