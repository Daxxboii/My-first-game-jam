using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_respawn : MonoBehaviour
{
    private GameObject respawn_gameObject;
    private Respawn_trigger _trigger;
    // Start is called before the first frame update
    void Start()
    {
        respawn_gameObject = GameObject.FindWithTag("Respawn");
        _trigger = respawn_gameObject.GetComponent<Respawn_trigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_trigger.triggered)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            _trigger.triggered = false;
        }
        
    }
}
