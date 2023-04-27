using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Disclaimer : MonoBehaviour
{
    public Animator revealDisclaimerAnim;
    public GameObject revealTransition;
    public GameObject quitbutton;
    public GameObject proceedButton;


    private void Start()
    {
        StartCoroutine(RevealDisclaiemer());
    }

    public IEnumerator RevealDisclaiemer()
    {
        yield return new WaitForSeconds(1f);
        revealDisclaimerAnim.Play("RevealDisclaimer");
        yield return new WaitForSeconds(4f);
        revealTransition.SetActive(false);
        quitbutton.SetActive(true);
        proceedButton.SetActive(true);
    }
       
    public void Proceed()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
    
}
