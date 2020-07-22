using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;


// Doing this the obsolete way because it seems to work the best for the anims
public class Player_animation : MonoBehaviour
{
    public Animator anim;

    private Quaternion flip_rotation;
    private Quaternion normal_rotation;
  
    private bool flip;

    

    private void Start()
    {
        flip = false;
        flip_rotation = Quaternion.Euler(0f,-90f,0f);
        normal_rotation = Quaternion.Euler(0f, 90f, 0f);

    }

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            flip = true;
            anim.SetInteger("Horizontal", 1);
        }
        
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            flip = false;
            anim.SetInteger("Horizontal", 1);
        }

        else
        {
            anim.SetInteger("Horizontal", 0);
        }
        Flip();
       
    }

    void Flip()
    {
        if( flip == true)
        {
            transform.rotation = flip_rotation;
        }
        else
        {
            transform.rotation = normal_rotation;
        }
    }

}
