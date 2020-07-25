﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_health : MonoBehaviour
{
    public Enemy_details details;
    public Slider health_slider;
    public Gradient health_color;
    public Image fill;

    [HideInInspector]
    private float health;

    private void Awake()
    {
        health = details.health;
        health_slider.maxValue = health;
        health_slider.value = health;
    }

    private void FixedUpdate()
    {
        health_slider.value = health;
        fill.color = health_color.Evaluate(health / health_slider.maxValue);
        Die();
    }

    public void Die()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


}
