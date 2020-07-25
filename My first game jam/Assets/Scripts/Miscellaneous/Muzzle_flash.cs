using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muzzle_flash : MonoBehaviour
{
    private float i;
    private Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = transform.GetComponent<Light>();
        InvokeRepeating("Blink", 0f, 0.1f);
    }

    void Blink()
    {
        i++;
        if (i % 2 == 0)
        {
            light.enabled = false;
        }
        else
        {
            light.enabled = true;
        }
    }

    
}
