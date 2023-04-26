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

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator EndCredits()
    {
        titleAnim.Play("Credits1");
        yield return new WaitForSeconds(3f);
        creditsAnim.Play("Credits2");
        skipButton.SetActive(true);

    }

    public void SkipCredits()
    {
        Application.Quit();
    }
}
