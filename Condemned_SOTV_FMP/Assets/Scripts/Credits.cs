using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public Animator titleAnim;
    public Animator creditsAnim;
    public GameObject skipButton;
    void Start()
    {
        StartCoroutine(EndCredits());
    }

    void Update()
    {
        
    }

    public IEnumerator EndCredits()
    {
        titleAnim.Play("Credits1");
        yield return new WaitForSeconds(2f);
        creditsAnim.Play("Credits2");
        yield return new WaitForSeconds(3f);
        skipButton.SetActive(true);
        Cursor.visible = true;
        yield return new WaitForSeconds(17f);
        SceneManager.LoadScene("Menu");
        

    }

    public void SkipCredits()
    {
        SceneManager.LoadScene("Menu");
    }
}
