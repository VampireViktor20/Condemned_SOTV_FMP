using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Polaroid : MonoBehaviour
{

    [Header("Polaroid Added")]
    [SerializeField] private Image polaroidDisplayArea;
    [SerializeField] private GameObject PolaroidFrame;
    [SerializeField] private GameObject PolaroidUI;

    [Header("Polaroid FLash")]
    [SerializeField] private GameObject PolaroidFlash;
    [SerializeField] private float flashDuration;

    [Header("Polaroid Fader Effect")]
    [SerializeField] private Animator fadingAnim;
    [SerializeField] private Animator printingAnim;

    [Header("Polaroid Sound")]
    [SerializeField] private AudioSource polaroidSound;

    private Texture2D polaroidCapture;
    public bool viewingPolaroid = false;
    public bool capturingPolaroid = false;


    public float distance;
    public Transform playerSocket;
    public Item item;
    public GameObject interactIcon;
   

    public PlayerMovement player;

    Vector3 originalPos;
    public bool onExamine = false;
    GameObject examined;
    private void Start()
    {
        polaroidCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
    }

    private void Update()
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
                    viewingPolaroid = true;
                    examined = hit.transform.gameObject;
                    originalPos = hit.transform.position;
                    item = hit.transform.gameObject.GetComponent<Item>();
                    onExamine = true;
                    PolaroidUI.SetActive(true);

                    StartCoroutine(PickupItem());
                }
            }
            else
            {
                
                interactIcon.SetActive(false);
            }
        }

       if(onExamine)
        {
            if(Input.GetMouseButtonDown(0))
            {
               if(!viewingPolaroid && !capturingPolaroid)
                {
                    StartCoroutine(CapturePolaroid());
                }
               else if (viewingPolaroid)
                {
                    RemovePolaroid();
                }
            }
        }

        if(onExamine)
        {
            
                
            playerSocket.Rotate(new Vector3(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0) * Time.deltaTime * 350f);
            examined.transform.position = Vector3.Lerp(examined.transform.position, playerSocket.position, 0.2f);
        }
        else if(examined != null)
        {
            examined.transform.SetParent(null);
            examined.transform.position = Vector3.Lerp(examined.transform.position, originalPos, 0.2f);
        }



        if (Input.GetKeyDown(KeyCode.Mouse1) && onExamine)
        {

            StartCoroutine(DropItem());
            onExamine = false;
            PolaroidUI.SetActive(false);
        }



    }

    IEnumerator PickupItem()
    {
        player.enabled = false;
        yield return new WaitForSeconds(0.2f);
        examined.transform.SetParent(playerSocket);
    }

    IEnumerator DropItem()
    {
        onExamine = false;
        examined.transform.rotation = Quaternion.identity;
        yield return new WaitForSeconds(2f);
        player.enabled = true;
    }

    IEnumerator CapturePolaroid()
    {
        capturingPolaroid = true;
        PolaroidUI.SetActive(false);
        viewingPolaroid = true;

        yield return new WaitForEndOfFrame();

        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);

        polaroidCapture.ReadPixels(regionToRead, 0, 0, false);
        polaroidCapture.Apply();
        ShowPolaroid();
        StartCoroutine(DropItem());
        item.gameObject.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        printingAnim.Play("PolaroidPrint");
        yield return new WaitForSeconds(0.5f);
        capturingPolaroid = false;
        RemovePolaroid();
        
        
    }

    void ShowPolaroid()
    {
        Sprite polaroidSprite = Sprite.Create(polaroidCapture, new Rect(0.0f, 0.0f, polaroidCapture.width, polaroidCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
        polaroidDisplayArea.sprite = polaroidSprite;
        PolaroidFrame.SetActive(true);
        StartCoroutine(PolaroidFlashEffect());
        fadingAnim.Play("PolaroidFade");
        
    }

    IEnumerator PolaroidFlashEffect()
    {
        polaroidSound.Play();
        PolaroidFlash.SetActive(true);
        yield return new WaitForSeconds(flashDuration);
        PolaroidFlash.SetActive(false);
    }

    void RemovePolaroid()
    {
        viewingPolaroid = false;
        PolaroidFrame.SetActive(false);
        //PolaroidUI.SetActive(true);
    }

   


}
