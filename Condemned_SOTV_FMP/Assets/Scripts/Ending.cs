using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public GameObject endingScreen;
    public Animator endTransition;



    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Player")
        {
            StartCoroutine(EndEvent());
        }

    }

    public IEnumerator EndEvent()
    {
        endingScreen.SetActive(true);
        endTransition.Play("Ending");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Credits");
        
        
    }
}
