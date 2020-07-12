using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_script : MonoBehaviour
{
    public GameObject[] all;
    void Start()
    {
      all = SceneManager.GetActiveScene().GetRootGameObjects();
        assign();
    }
    public void assign()
    {
        foreach (GameObject obj in all)
        {
            if (obj.tag != "UI" )
            {
                obj.AddComponent<Rewind>();
            }
        }
    }


}
