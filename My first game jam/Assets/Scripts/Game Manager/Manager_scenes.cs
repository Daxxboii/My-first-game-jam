using System.Collections;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager_scenes : MonoBehaviour
{
    public GameObject white_screen;
    public Slider loading;

    private void Awake()
    {
        white_screen.SetActive(false);
    }
    public void LoadLevel (int index)
    {
        StartCoroutine(LoadAsynchronously(index));
    } 

    IEnumerator LoadAsynchronously(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        while (!operation.isDone)
        {
            white_screen.SetActive(true);
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loading.value = progress;
            yield return null;
        }
        
       
    }


        

}
