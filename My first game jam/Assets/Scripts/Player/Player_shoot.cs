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
    private Enemylizdie enemy_health_1;
    RaycastHit hit;
    [Header("Wwise")]
    public AK.Wwise.Event PlayerIsShooting;
    public float timeBetweenShots = 0.1f;

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Cast();
            trail.Play();
            PlayerIsShooting.Post(gameObject);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (hit.transform.gameObject.tag == "Enemy")
            {
                enemy_health.hit = false;
            }
            if (hit.transform.gameObject.tag == "Enemy1")
            {
                enemy_health_1.hit = false;
            }
            trail.Stop();
        }
    }

    void Cast()
    {
       
        if (Physics.Raycast(muzzle.transform.position, muzzle.transform.TransformDirection(Vector3.forward), out hit, Range))
        {

            if (hit.transform.gameObject.tag == "Enemy")
            {
                enemy_health = hit.transform.gameObject.GetComponent<Enemy_health>();
                enemy_health.hit = true;
               

            }
            if(hit.transform.gameObject.tag == "Enemy1")
            {
                enemy_health_1 = hit.transform.gameObject.GetComponent<Enemylizdie>();
                enemy_health_1.hit = true;
            }
        }
    }

}
