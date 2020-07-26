using UnityEngine;
using System.Collections;
using System;
using JetBrains.Annotations;
using UnityEngine.AI;
using UnityEditor;

public class Enemy_attack : MonoBehaviour
{
    public Enemy_details details;
    public NavMeshAgent Navmesh;
    private GameObject player;


    public Animator anim;
    public float range;
 
    private bool triggered;



    

    private bool hit;
  

    private Player_health player_health;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        player_health = player.transform.GetComponent<Player_health>();
        anim.SetBool("Attack", false);
    }


    private void FixedUpdate()
    {
        Navmesh.speed = details.speed;
        if (Vector3.Distance(player.transform.position, transform.position) <= range)
        {
            Navmesh.SetDestination(player.transform.position);
            triggered = true;
           
            anim.SetBool("Attack", false);
        }
      
        if (details.type == Enemy_details.Type.shoot)
        {
            if (triggered )
            {
                Shoot();
            }

        }
        else
        {
            if (triggered)
            {
                Meelee();
            }
        }
    }

    void Shoot()
    {
        anim.SetBool("Attack", true);
      
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("Attack", true);
            
            
            hit = true;
          
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("Attack", true);


            hit = true;
       
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Exit();
        

    }
    void Meelee()
    {
        if(hit == true)
        {
            player_health.hit = true;
            
        }
        else
        {
            player_health.hit = false;
        }
    }
    public void Exit()
    {
        anim.SetBool("Attack", false);
        player_health.hit = false;
        
        hit = false;
    }
}
