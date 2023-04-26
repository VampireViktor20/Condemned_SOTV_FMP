using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSound : MonoBehaviour
{
    public AudioSource doorOpen;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Player")
        {
            doorOpen.Play();
            Destroy(gameObject, 1.5f);
        }

    }
}
