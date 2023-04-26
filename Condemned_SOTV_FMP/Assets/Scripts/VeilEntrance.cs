using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VeilEntrance : MonoBehaviour
{
    public GameObject mirror;
    public GameObject shatterEffect;
    public Animator veilTransitionAnim;
    public GameObject veilTransitionScreen;
    public AudioSource mirrorBreak;
   

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Player")
        {
            StartCoroutine(VeilTransition());
        }

    }

    IEnumerator VeilTransition()
    {

        mirrorBreak.Play();
        shatterEffect.SetActive(true);
        mirror.SetActive(false);
        veilTransitionScreen.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        veilTransitionAnim.Play("VeilTransition");
        yield return new WaitForSeconds(veilTransitionAnim.GetCurrentAnimatorStateInfo(0).length);
        SceneManager.LoadScene("Loading2");
    }
}
