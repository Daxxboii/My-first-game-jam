using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn_trigger : MonoBehaviour
{
    [HideInInspector]
    public bool triggered = false;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            triggered = true;
        }
    }
}
