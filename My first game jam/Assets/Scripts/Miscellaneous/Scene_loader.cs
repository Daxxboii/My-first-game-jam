using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene_loader : MonoBehaviour
{
    Scene scene;
    private GameObject manager;
    private Manager_scenes manager_script;
   

    private void Awake()
    {
        manager = GameObject.FindWithTag("Manager");
        manager_script = manager.transform.GetComponent<Manager_scenes>();
        scene = SceneManager.GetActiveScene();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            manager_script.LoadLevel(scene.buildIndex+1);
           
        }
      
    }
}
