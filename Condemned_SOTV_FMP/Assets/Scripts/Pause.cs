using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] public GameObject optionsUI;
    [SerializeField] public GameObject pauseUI;
    [SerializeField] private bool isPaused;


    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if(isPaused)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Paused();
            Cursor.visible = true;
        }

        else
        {
            
            Resume();
        }
    }

   public void Paused()
    {

        Time.timeScale = 0f;

        AudioListener.pause = true;
        pauseUI.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        pauseUI.SetActive(false);
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

    
