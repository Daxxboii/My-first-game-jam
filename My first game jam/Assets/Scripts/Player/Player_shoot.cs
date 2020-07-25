using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_shoot : MonoBehaviour
{
    public GameObject particle_system;
    public float Range;
    public GameObject muzzle;

    private Enemy_health enemy_health;
    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Range))
        {
            if (hit.transform.gameObject.tag == "Enemy")
            {
                enemy_health = hit.transform.gameObject.GetComponent<Enemy_health>();

            }
        }
    }

}
