﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Computer : MonoBehaviour
{

    [SerializeField] public float distance;
    [SerializeField] public bool usingComputer;
    [SerializeField] public GameObject computerText;
    [SerializeField] public GameObject computerUI;
    [SerializeField] PlayerMovement player;
    [SerializeField] public PlayerCamera playercam;
    [SerializeField] public FreeCam freecam;

    void Update()
    {

        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, fwd, out hit, distance))
        {
            if (hit.transform.tag == "Computer" && !usingComputer)
            {
                computerText.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.Confined;
                    usingComputer = true;
                    computerUI.SetActive(true);
                    player.enabled = false;
                    playercam.enabled = false;
                    //freecam.enabled = false;
                    


                }

            }
            else
            {
                usingComputer = false;
                computerText.SetActive(false);
            }
            
            
        }
      
    }
}
