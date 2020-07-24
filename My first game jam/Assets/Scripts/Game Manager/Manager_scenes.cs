using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager_scenes : MonoBehaviour
{
   
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Credits()
    {
        SceneManager.LoadScene(1);
    }

    public void Game()
    {
        SceneManager.LoadScene(2);
    }

}
