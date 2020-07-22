using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_animation : MonoBehaviour
{
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
       



        // jump
        if (Input.GetButton("Jump") || Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w"))
        {
            anim.SetTrigger("Jump Trigger");
        }
        else
        {

        }


    }

}
