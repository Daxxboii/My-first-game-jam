using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_health : MonoBehaviour
{
    public Enemy_details details;
    public Slider health_slider;
    public Gradient health_color;
    public Image fill;
    public CapsuleCollider collider;
    [HideInInspector]
    public bool hit;

    [HideInInspector]
    public float health;
    public Animator anim;
    public Enemy_attack attack;

    private void Awake()
    {
        health = details.health;
        health_slider.maxValue = health;
        health_slider.value = health;
       
        InvokeRepeating("Hit", 0.5f,0.5f);
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
            StartCoroutine(Fok());
            health = 1f;
        }
    }

    public void Hit()
    {
        if (hit == true)
        {
            health -= 5f;
        }
    }
    public IEnumerator Fok()
    {
        if (details.type == Enemy_details.Type.shoot)
        {
            collider.enabled = false;
            attack.Exit();
            attack.enabled = false;

            anim.SetBool("Attack", false);

            anim.SetBool("Die", true);
            yield return new WaitForSeconds(2);
        }
        Destroy(gameObject);
       
    }
    
}
