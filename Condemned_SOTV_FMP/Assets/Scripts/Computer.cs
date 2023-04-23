using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Computer : MonoBehaviour
{

    [SerializeField] public float distance;
    [SerializeField] public bool usingComputer;
    [SerializeField] public GameObject computerIcon;
    [SerializeField] public GameObject computerUI;
    [SerializeField] public GameObject loadScreenUI;
    [SerializeField] PlayerMovement player;
    [SerializeField] public PlayerCamera playercam;
    [SerializeField] public FreeCam freecam;
    [SerializeField] public AudioSource loginSound;
    [SerializeField] public Animator loadScreenAnim;
    [SerializeField] public bool loadedComputer;




    void Update()
    {

        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, fwd, out hit, distance))
        {
            if (hit.transform.tag == "Computer" && !usingComputer)
            {
                computerIcon.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Mouse0) && !usingComputer && !loadedComputer) 
                {
                    loadScreenUI.SetActive(true);
                    StartCoroutine(LoadScreen());
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.Confined;
                    usingComputer = true;
                    computerUI.SetActive(true);
                    player.enabled = false;
                    playercam.enabled = false;
                    freecam.enabled = false;
                    loadedComputer = true;
                    


                }

            }
            else
            {
                usingComputer = false;
                computerIcon.SetActive(false);
        
            }
            
            
        }
      
    }

    IEnumerator LoadScreen()
    {
        loadScreenAnim.Play("ComputerLoad");
        loginSound.Play();
        yield return new WaitForSeconds(0.5f);
        loadScreenUI.SetActive(false);
        
    }
}
