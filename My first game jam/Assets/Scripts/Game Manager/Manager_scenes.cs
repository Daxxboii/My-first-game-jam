using System.Collections;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class Manager_scenes : MonoBehaviour
{
    public GameObject LoadScreen;

    private void Awake()
    {
       
    }
    public void LoadLevel (int index)
    {
        StartCoroutine(LoadAsynchronously(index));
    } 

    IEnumerator LoadAsynchronously(int index)
    {
        LoadScreen.SetActive(true);
        yield return new WaitForSeconds(5);
     
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        while (!operation.isDone)
        {
          
            yield return null;
        }
        
       
    }


        

}
