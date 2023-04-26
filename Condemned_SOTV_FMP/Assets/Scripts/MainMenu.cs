using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject optionsUI;
    public void Play()
    {
        SceneManager.LoadScene("Intro");
    }

    public void Options()
    {
        optionsUI.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    
}
