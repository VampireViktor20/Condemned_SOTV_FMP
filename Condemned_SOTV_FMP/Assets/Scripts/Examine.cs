using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Examine : MonoBehaviour
{
    public float distance;
    public Transform playerSocket;
    public Item item;
    public GameObject interactIcon;
    //public GameObject ItemText;

    public PlayerMovement player;

    Vector3 originalPos;
    public bool onExamine = false;
    GameObject examined;

    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if(Physics.Raycast(transform.position, fwd, out hit, distance))
        {
            if(hit.transform.tag == "Item" && !onExamine)
            {
                interactIcon.SetActive(true);
                if(Input.GetKeyDown(KeyCode.Mouse0))
                {
                    //ItemText.SetActive(true);
                    examined = hit.transform.gameObject;
                    originalPos = hit.transform.position;
                    item = hit.transform.gameObject.GetComponent<Item>();
                    onExamine = true;

                    StartCoroutine(pickupItem());
                }
            }
            else
            {
                interactIcon.SetActive(false);
            }
        }

        if(onExamine)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                //ItemText.SetActive(false);
                item = null;
            }
            playerSocket.Rotate(new Vector3(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0) * Time.deltaTime * 350f);
            examined.transform.position = Vector3.Lerp(examined.transform.position, playerSocket.position, 0.2f);
        }
        else if(examined != null)
        {
            examined.transform.SetParent(null);
            examined.transform.position = Vector3.Lerp(examined.transform.position, originalPos, 0.2f);
        }

        if(Input.GetKeyDown(KeyCode.Mouse1) && onExamine)
        {
            //ItemText.SetActive(false);
            StartCoroutine(dropItem());
            onExamine = false;
        }
    }

    IEnumerator pickupItem()
    {
        player.enabled = false;
        yield return new WaitForSeconds(0.2f);
        examined.transform.SetParent(playerSocket);
    }

    IEnumerator dropItem()
    {
        examined.transform.rotation = Quaternion.identity;
        yield return new WaitForSeconds(0.2f);
        player.enabled = true;
    }

}
