using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    
    public void StartGame()
    {
        SceneManager.LoadScene("World");
    }

    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
