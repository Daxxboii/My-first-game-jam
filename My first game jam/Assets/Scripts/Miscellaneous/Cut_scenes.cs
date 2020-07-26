using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cut_scenes : MonoBehaviour
{
    public float time;
    Scene scene;
    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        StartCoroutine(Stert());

    }

    IEnumerator Stert()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(scene.buildIndex + 1);
    }
}
