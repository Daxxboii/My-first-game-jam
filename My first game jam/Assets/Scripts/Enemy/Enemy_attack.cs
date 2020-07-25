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
   
    public float range;
    private float dist;
    private bool triggered;

    public Transform muzzle = null;
    public GameObject bullet = null;

    private bool hit;
    private Player_health player_health;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }


    private void FixedUpdate()
    {
        Navmesh.speed = details.speed;
        if (Vector3.Distance(player.transform.position, transform.position) <= range)
        {
            Navmesh.SetDestination(player.transform.position);
            triggered = true;
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

    private void OnCollision(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hit = true;
            player_health = collision.gameObject.transform.GetComponent<Player_health>();
        }
    }
    void Meelee()
    {
        if(hit == true)
        {
            player_health.player_health -= details.hit_damage;
            hit = false;
        }
    }
}
