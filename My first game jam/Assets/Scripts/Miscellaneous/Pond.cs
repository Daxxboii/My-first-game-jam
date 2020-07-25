using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pond : MonoBehaviour
{
    public GameObject child;
    private BoxCollider box;
    private float i;
    private void Start()
    {
        box = this.gameObject.transform.GetComponent<BoxCollider>();

        InvokeRepeating("Blink", 0f, 3f);
    }

    void Blink()
    {
        i++;
        if (i % 3 == 0)
        {
            box.enabled = false;
            child.SetActive(false);
        }
        else
        {
            box.enabled = true;
            child.SetActive(true);
        }
    }
   
}
