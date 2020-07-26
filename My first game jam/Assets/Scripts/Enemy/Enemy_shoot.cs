using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_shoot : MonoBehaviour
{
    public Animator anim;
    public Transform muzzle;
   
    public NavMeshAgent navmesh;
    public float range;
    private GameObject player;
    private Player_health p_health;
    public GameObject Trail;
 


    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        p_health = player.transform.GetComponent<Player_health>();
        Trail.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= range)
        {
            navmesh.SetDestination(player.transform.position);
            anim.SetBool("Attack", true);
            Shoot();
        }
        else
        {
            anim.SetBool("Attack", false);
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(muzzle.transform.position, muzzle.transform.TransformDirection(Vector3.forward),out hit, range))
        {
            Debug.DrawRay(muzzle.transform.position, muzzle.transform.TransformDirection(Vector3.forward), Color.red, range);
            if (hit.transform.gameObject.tag == "Player")
            {
                Trail.SetActive(true);
                p_health.hit = true;
            }
            else
            {
                Trail.SetActive(false);
                p_health.hit = false;
            }
        }
    }

}
