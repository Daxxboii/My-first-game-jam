﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

using System.Security.Cryptography;
using UnityEngine;


// Doing this the obsolete way because it seems to work the best for the anims
public class Player_animation : MonoBehaviour
{
    public Animator anim;
    public float crouch_offset;
    public GameObject gun;

    private Quaternion flip_rotation;
    private Quaternion normal_rotation;
  
    private bool flip;

    private Vector3 offset;
    private Vector3 current_offset;

    public AK.Wwise.Event TeleporterBeepSound;

    private void Start()
    {
        flip = false;
        flip_rotation = Quaternion.Euler(0f,-90f,0f);
        normal_rotation = Quaternion.Euler(0f, 90f, 0f);
        current_offset = transform.localPosition;

        offset = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        offset.y = crouch_offset;


    }

    void FixedUpdate()
    {
      
       
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) ) && (Input.GetKey(KeyCode.D) == false && Input.GetKey(KeyCode.RightArrow) == false))
        {
            flip = true;
            transform.localPosition = current_offset;

            if ( Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown("w"))
            {
               
                anim.SetInteger("Vertical", 1);
             //   anim.SetInteger("Horizontal", 0);//out of bounds
               // Debug.Log("TaDaaaa");
            }
            else
            {
                anim.SetInteger("Horizontal", 1);
                anim.SetInteger("Vertical", 0);
                
            }
            if (Input.GetKey("c") || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
            {
                anim.SetInteger("Horizontal", 1);
                anim.SetInteger("Vertical", -1);
                transform.localPosition = offset;

                if (Input.GetButton("Jump") || Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w"))
                {
                    anim.SetInteger("Vertical", 1);
                    transform.localPosition = current_offset;
                }
            }

            if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))){
                flip = true;
            }

           


        }
        
      else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && (Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.LeftArrow) == false))
        {
            flip = false;
            transform.localPosition = current_offset;

            if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown("w"))
            {

                anim.SetInteger("Vertical", 1);
                //   anim.SetInteger("Horizontal", 0);//out of bounds
              //  Debug.Log("TaDaaaa");
            }
            else
            {
                anim.SetInteger("Horizontal", 1);
                anim.SetInteger("Vertical", 0);
            }

            if (Input.GetKey("c") || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
            {
                anim.SetInteger("Horizontal", 1);
                anim.SetInteger("Vertical", -1);
                transform.localPosition = offset;
                if (Input.GetButton("Jump") || Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w"))
                {
                    anim.SetInteger("Vertical", 1);
                    transform.localPosition = current_offset;
                }
            }
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
            {
                flip = false;
            }
        }

        else if(Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown("w")) {
            anim.SetInteger("Horizontal", 0);
            anim.SetInteger("Vertical", 1);
        }

        else if (Input.GetKey("c") || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
        {
            anim.SetInteger("Horizontal", 0);
            anim.SetInteger("Vertical", -1);
            transform.localPosition = offset;

           
        }

     
       


        else
        {
            anim.SetInteger("Horizontal", 0);
            anim.SetInteger("Vertical", 0);
            anim.SetBool("Shoot", false);
            transform.localPosition = current_offset;
        }
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.KeypadEnter))
        {
            anim.SetBool("Shoot", true);
        }
        else
        {
            StartCoroutine(Wait());
            anim.SetBool("Shoot", false);
        }

        if (anim.GetBool("Shoot"))
        {
            gun.SetActive(true);
        }

        else
        {
            gun.SetActive(false);
        }
        Flip();
      
        //  Debug.Log(anim.GetFloat("Vertical"));

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

    void PlayTeleporterBeep()
    {
        TeleporterBeepSound.Post(gameObject);
    }

    IEnumerator Wait()
    {
        yield  return new WaitForSeconds(2);
    }
}
