using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_health : MonoBehaviour
{
    public Slider health_slider;
    public Gradient health_color;
    public Image fill;

    public float player_health;
    
    private Player_details details;
    private Player_movement move_script;

    [HideInInspector]
    public bool hit;

    void Awake()
    {
        move_script = this.gameObject.transform.GetComponent<Player_movement>();
        details = move_script.move_details;
       
         
        player_health = details.health;
        health_slider.maxValue = player_health;
        health_slider.value = player_health;

        InvokeRepeating("Hit", 0.5f, 0.5f);
    }

    void FixedUpdate()
    {
        health_slider.value = player_health;
        fill.color = health_color.Evaluate(player_health / health_slider.maxValue);
        Die();
    }

    public void Hit()
    {
        if(hit == true)
        {
            player_health -= 10f;
            hit = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet" )
        {
            player_health -= 30f;
            Destroy(collision.gameObject);
        }
    }
    public void Die()
    {
        if (player_health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
