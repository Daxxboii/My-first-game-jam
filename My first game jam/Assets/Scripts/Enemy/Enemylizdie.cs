using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemylizdie : MonoBehaviour
{
    public Enemy_details details;
    public Slider health_slider;
    public Gradient health_color;
    public Image fill;

    [HideInInspector]
    public bool hit;

    [HideInInspector]
    public float health;
  

    // Start is called before the first frame update
    void Start()
    {
        health = details.health;
        health_slider.maxValue = health;
        health_slider.value = health;
        InvokeRepeating("Hit", 0.5f, 0.5f);
    }

    private void FixedUpdate()
    {
        health_slider.value = health;
        fill.color = health_color.Evaluate(health / health_slider.maxValue);
        Die();
    }

    public void Hit()
    {
        if (hit == true)
        {
            health -= 5f;
        }
    }

    public void Die()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
