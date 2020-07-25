using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_shoot : MonoBehaviour
{
 
    public float Range = 5f;
    public GameObject muzzle;
    public float damage = 10f;

    public ParticleSystem trail;

    private Enemy_health enemy_health;
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Cast();
            trail.Play();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            enemy_health.hit = false;
            trail.Stop();
        }
    }

    void Cast()
    {
        RaycastHit hit;
        if (Physics.Raycast(muzzle.transform.position, muzzle.transform.TransformDirection(Vector3.forward), out hit, Range))
        {

            if (hit.transform.gameObject.tag == "Enemy")
            {
                enemy_health = hit.transform.gameObject.GetComponent<Enemy_health>();
                enemy_health.hit = true;

            }
        }
    }

}
