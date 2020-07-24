using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class Player_health : MonoBehaviour
{
    public Slider health_slider;
    public Gradient health_color;
    public Image fill;

    public float player_health;
    
    private Player_details details;
    private Player_movement move_script;

    void Awake()
    {
        move_script = this.gameObject.transform.GetComponent<Player_movement>();
        details = move_script.move_details;
       
         
        player_health = details.health;
        health_slider.maxValue = player_health;
        health_slider.value = player_health;
    }

    void FixedUpdate()
    {
        health_slider.value = player_health;
        fill.color = health_color.Evaluate(player_health / health_slider.maxValue);
    }
}
