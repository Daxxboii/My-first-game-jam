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



    public Transform muzzle = null;
    public GameObject bullet = null;

    private bool hit;
    private Player_health player_health;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        anim.SetBool("Stand", true);
        anim.SetBool("Attack", false);
    }


    private void FixedUpdate()
    {
        Navmesh.speed = details.speed;
        if (Vector3.Distance(player.transform.position, transform.position) <= range)
        {
            Navmesh.SetDestination(player.transform.position);
            triggered = true;
            anim.SetBool("Stand", false);
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
        Instantiate(bullet, muzzle);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("Attack", true);
            anim.SetBool("Stand", true);
            hit = true;
            player_health = collision.gameObject.transform.GetComponent<Player_health>();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        anim.SetBool("Attack", false);
        anim.SetBool("Stand", false);
        hit = false;

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
}
