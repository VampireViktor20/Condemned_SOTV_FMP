using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject optionsUI;
    public Animator menuRevealAnim;
    public GameObject revealScreen;

    void Start()
    {
        StartCoroutine(RevealMenu());
        Cursor.lockState = CursorLockMode.Confined;
    }
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

    public IEnumerator RevealMenu()
    {
        yield return new WaitForSeconds(0f);
        menuRevealAnim.Play("RevealDisclaimer");
        yield return new WaitForSeconds(1.25f);
        revealScreen.SetActive(false);
    }

    
}
