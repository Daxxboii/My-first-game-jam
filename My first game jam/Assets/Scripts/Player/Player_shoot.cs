using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_shoot : MonoBehaviour
{
    public GameObject particle_system;
    public float Range;


    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Range))
        {
            if (hit.transform.gameObject.tag == "Enemy")
            {

            }
        }
    }

}
