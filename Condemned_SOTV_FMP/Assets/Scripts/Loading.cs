using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public Animator loadingAnim;

    private bool hasStartedLoading = false;

    void Start()
    {
        loadingAnim.Play("Loading");
    }

    void Update()
    {
        if (!hasStartedLoading && loadingAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 4f)
        {
            hasStartedLoading = true;
            LoadScene();
        }
    }

    private void LoadScene()
    {
        string sceneToLoad = "";

        switch (SceneManager.GetActiveScene().name)
        {
            case "Loading1":
                sceneToLoad = "Main";
                break;
            case "Loading2":
                sceneToLoad = "Veil";
                break;
            case "Loading3":
                sceneToLoad = "Ending";
                break;
        }

        SceneManager.LoadScene(sceneToLoad);
    }

}