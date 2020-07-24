using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors_open : MonoBehaviour
{
    private Animator door;
    private BoxCollider collider;

    public AK.Wwise.Event OpenDoorSound;

    void Awake()
    {
        door = this.gameObject.transform.GetComponent<Animator>();
        collider = this.gameObject.GetComponent<BoxCollider>();
    }
    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            door.SetBool("Open", true);
            collider.enabled = false;
            OpenDoorSound.Post(gameObject);
        }
    }
}
