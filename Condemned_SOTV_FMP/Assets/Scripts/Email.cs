using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Email : MonoBehaviour
{

    public GameObject emailApp;
    public GameObject email;
    public PlayerMovement player;
    public PlayerCamera cam;
    public FreeCam freecam;
    public Computer computer;

    void Update()
    {
        player.enabled = false;

    }

    
    public void OpenApp()
    {
        emailApp.SetActive(true);
    }

    public void CloseApp()
    {
        emailApp.SetActive(false);
    }

    public void ViewEmail()
    {
        email.SetActive(true);
    }

    public void CloseEmail()
    {
        email.SetActive(false);
    }

    public void Logout()
    {
        computer.computerUI.SetActive(false);
        computer.loadedComputer = false;
        player.enabled = true;
        cam.enabled = true;
        freecam.enabled = true;
        Cursor.visible = false;
        
    }

}
