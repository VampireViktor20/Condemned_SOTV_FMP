using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Examine examine;
    public PlayerMovement player;

 

    public IEnumerator ItemAdded()
    {
        examine.GetComponent<Examine>().onExamine = false;
        player.enabled = true;
        gameObject.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
