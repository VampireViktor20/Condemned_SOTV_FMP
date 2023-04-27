using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScene : MonoBehaviour
{
    public Animator lightFlashAnim;
    public Animator introflashAnim;
    public Animator introAnim;
    public AudioSource FlashSound;
    public GameObject transitionScreen;


     void Start()
    {
        Cursor.visible = false;
        StartCoroutine(Intro());
    }

    IEnumerator Intro()
    {

        yield return new WaitForSeconds(1f);
        introAnim.Play("Intro");
        lightFlashAnim.SetTrigger("Reset");
        lightFlashAnim.Play("LightFlash");
        introflashAnim.SetTrigger("Reset");
        introflashAnim.Play("IntroFlash");
        FlashSound.Play();
        yield return new WaitForSeconds(1f);
        lightFlashAnim.SetTrigger("Reset");
        lightFlashAnim.Play("LightFlash");
        introflashAnim.SetTrigger("Reset");
        introflashAnim.Play("IntroFlash");
        lightFlashAnim.SetTrigger("Reset");
        lightFlashAnim.Play("LightFlash");
        introflashAnim.SetTrigger("Reset");
        introflashAnim.Play("IntroFlash");
        FlashSound.Play();
        yield return new WaitForSeconds(1.5f);
        lightFlashAnim.SetTrigger("Reset");
        lightFlashAnim.Play("LightFlash");
        introflashAnim.SetTrigger("Reset");
        introflashAnim.Play("IntroFlash");
        FlashSound.Play();
        yield return new WaitForSeconds(1f);
        lightFlashAnim.SetTrigger("Reset");
        lightFlashAnim.Play("LightFlash");
        introflashAnim.SetTrigger("Reset");
        introflashAnim.Play("IntroFlash");
        FlashSound.Play();
        yield return new WaitForSeconds(0.5f);
        lightFlashAnim.SetTrigger("Reset");
        lightFlashAnim.Play("LightFlash");
        introflashAnim.SetTrigger("Reset");
        introflashAnim.Play("IntroFlash");
        lightFlashAnim.SetTrigger("Reset");
        lightFlashAnim.Play("LightFlash");
        introflashAnim.SetTrigger("Reset");
        introflashAnim.Play("IntroFlash");
        lightFlashAnim.SetTrigger("Reset");
        lightFlashAnim.Play("LightFlash");
        introflashAnim.SetTrigger("Reset");
        introflashAnim.Play("IntroFlash");
        FlashSound.Play();
        yield return new WaitForSeconds(1f);
        transitionScreen.SetActive(true);
        FlashSound.Play();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Loading1");
        

    }
}
