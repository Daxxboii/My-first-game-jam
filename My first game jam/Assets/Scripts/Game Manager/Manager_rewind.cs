using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_rewind : MonoBehaviour
{
  public GameObject rewind_button;
    public Rewind rewind;
    public GameObject player;
    void Start()
    {
        rewind_button = GameObject.FindWithTag("Rewind");
        player = GameObject.FindWithTag("Player");
       
        rewind = player.gameObject.GetComponent<Rewind>();
        rewind_button.SetActive(false);

    }
    void FixedUpdate() {
        if(rewind.Is_rewinding == true)
        {
            rewind_button.SetActive(true);

        }
        else
        {
            rewind_button.SetActive(false);
        }
    }
   
}
