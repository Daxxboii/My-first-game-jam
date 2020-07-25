using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_loader : MonoBehaviour
{
    private GameObject manager;
    private Manager_scenes manager_script;
    public int nxt_scene;

    private void Awake()
    {
        manager = GameObject.FindWithTag("Manager");
        manager_script = manager.transform.GetComponent<Manager_scenes>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            manager_script.LoadLevel(nxt_scene);
            Debug.Log("Hii");
        }
      
    }
}
