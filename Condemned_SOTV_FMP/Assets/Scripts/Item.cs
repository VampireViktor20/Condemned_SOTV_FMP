using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Polaroid polaroid;
    public PlayerMovement player;
    public string ItemName;

    public void Start()
    {

        if(polaroid == null)
        {
            polaroid = GameObject.Find("Player").GetComponentInChildren<Polaroid>();
            player = GameObject.Find("Player").GetComponent<PlayerMovement>();
   
        }
    }


    public IEnumerator ItemAdded()
    {
        polaroid.GetComponent<Polaroid>().onExamine = false;
        player.enabled = true;
        gameObject.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
