using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    private Player_health health;
    private bool hit;

    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Hit", 0f, 1f);
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("yo boii" + collision.gameObject.tag);
        if(collision.gameObject.tag == "Player")
        {
            health = collision.gameObject.transform.GetComponent<Player_health>();
            hit = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hit = false;
        }
    }

    void Hit()
    {
      if(hit == true)
      {
        health.player_health -= damage;
      }       
    }
}
