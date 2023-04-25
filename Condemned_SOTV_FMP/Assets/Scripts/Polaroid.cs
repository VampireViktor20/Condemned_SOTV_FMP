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
    [SerializeField] private Texture2D polaroidCapture;
    [SerializeField] private GameObject polaroidPrefab;
    [SerializeField] private Transform  polaroidParent;
    [SerializeField] private GameObject polaroidInstance;
    [SerializeField] public List<Transform> spawnPoints;
    [SerializeField] private int currentSpawnPointIndex;
    [SerializeField] private int polaroidCount = 0;


    [Header("Polaroid Flash")]
    [SerializeField] private GameObject PolaroidFlash;
    [SerializeField] private float flashDuration;

    [Header("Animations")]
    [SerializeField] private Animator fadingAnim;
    [SerializeField] private Animator printingAnim;
    [SerializeField] private Animator newEmailAnim;

    [Header("Sounds")]
    [SerializeField] private AudioSource polaroidSound;
    [SerializeField] private AudioSource newEmailSound;

    public bool examineMode = true;
    public bool viewingPolaroid = false;
    public bool capturingPolaroid = false;


    [Header("Examine Item")]
    [SerializeField] public Text itemNameText;
    [SerializeField] public List<GameObject> items;
    [SerializeField] public List<GameObject> emails;
    [SerializeField] public float distance;
    [SerializeField] public Transform playerSocket;
    [SerializeField] public Item item;
    [SerializeField] public GameObject interactIcon;
    [SerializeField] public GameObject polaroidIcon;
    [SerializeField] public GameObject emailAlert;
    [SerializeField] public PlayerMovement player;
    [SerializeField] public FreeCam freecam;
    [SerializeField] Vector3 originalPos;
    [SerializeField] private Vector3 originalSocketPos;
    [SerializeField] public bool onExamine = false;
    [SerializeField] GameObject examined;



    public float zoomSpeed = 2f;

    private void Start()
    {
        currentSpawnPointIndex = 0;
        polaroidCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        originalSocketPos = playerSocket.localPosition;
    }

    private void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;


        if(Physics.Raycast(transform.position, fwd, out hit, distance))
        {
            if(hit.transform.tag == "Polaroid" && !onExamine)
                
            {
                polaroidIcon.SetActive(true);
                if(Input.GetMouseButtonDown(0))
                {
                    examined = hit.transform.gameObject;
                    originalPos = hit.transform.position;

                    if (hit.transform.tag == "Polaroid")
                    {
                        playerSocket.localPosition = new Vector3(0f, 1.5f, 0.9f);
                    }
                    item = hit.transform.gameObject.GetComponent<Item>();
                    itemNameText.text = item.ItemName;
                    onExamine = true;
                    StartCoroutine(PickupItem());
                }
            }
            else
            {
                polaroidIcon.SetActive(false); 
            }

            if(hit.transform.tag == "Item" && !onExamine)
            {
                interactIcon.SetActive(true);
                if(Input.GetKeyDown(KeyCode.Mouse0))
                {
                    examined = hit.transform.gameObject;
                    originalPos = hit.transform.position;
                    item = hit.transform.gameObject.GetComponent<Item>();
                    itemNameText.text = item.ItemName;
                    onExamine = true;
                    StartCoroutine(PickupItem());
                }
            }
            else
            {
                
                interactIcon.SetActive(false);
            }
        }

        if(!onExamine && playerSocket.localPosition != originalSocketPos)
        {
            playerSocket.localPosition = originalSocketPos;
        }

       if(onExamine && !examineMode)
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
            if(Input.mouseScrollDelta.y !=0)
            {
                Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView - Input.mouseScrollDelta.y * zoomSpeed, 10f, 60f);
            }

            playerSocket.Rotate(new Vector3(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0) * Time.deltaTime * 350f);
            examined.transform.position = Vector3.Lerp(examined.transform.position, playerSocket.position, 0.2f);
         
        }
        else if(examined != null)
        {
            Camera.main.fieldOfView = 60f;
            examined.transform.SetParent(null);
            examined.transform.position = Vector3.Lerp(examined.transform.position, originalPos, 0.2f);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && onExamine)
        {
            examineMode = true;
            itemNameText.text = "";
            StartCoroutine(DropItem());
            onExamine = false;
            PolaroidUI.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.E) && onExamine)
        {
            if (examined.tag == "Polaroid")
            {
                examineMode = false;
                PolaroidUI.SetActive(false);
            }
            examineMode = !examineMode;
            if (examineMode)
            {
                PolaroidUI.SetActive(false);
            }
            else
            {
                PolaroidUI.SetActive(true); 
            }
        }
        

       

    }

    IEnumerator PickupItem()
    {
        freecam.enabled = false;
        player.enabled = false;
        yield return new WaitForSeconds(0.2f);
        examined.transform.SetParent(playerSocket);
    }

    IEnumerator DropItem()
    {
        PolaroidUI.SetActive(false);
        onExamine = false;
        examined.transform.rotation = Quaternion.identity; 
        yield return new WaitForSeconds(0.2f);
        player.enabled = true;
        freecam.enabled = true;
    }

    private void InstantiatePolaroid(Item item)
    {
        this.item = item;

        GameObject newPolaroid = Instantiate(polaroidPrefab, polaroidParent);
        polaroidCount++;
        newPolaroid.GetComponent<Item>().ItemName = item.ItemName;
        Transform polaroidChild = newPolaroid.transform.Find("PolaroidPhoto");
        polaroidChild.GetComponent<Renderer>().material.mainTexture = polaroidCapture;

        int randomIndex = Random.Range(0, spawnPoints.Count);
        Transform nextSpawnPoint = spawnPoints[currentSpawnPointIndex];
        currentSpawnPointIndex = (currentSpawnPointIndex + 1) % spawnPoints.Count;
        newPolaroid.transform.position = nextSpawnPoint.position;

        polaroidInstance = newPolaroid;

        if(currentSpawnPointIndex == 1)
        {
            SpawnPointUsedEvent1();
        }
        if (currentSpawnPointIndex == 2)
        {
            SpawnPointUsedEvent2();
        }
        if (currentSpawnPointIndex == 3)
        {
            SpawnPointUsedEvent3();
        }
        if (currentSpawnPointIndex == 4)
        {
            SpawnPointUsedEvent4();
        }
        if (currentSpawnPointIndex == 5)
        {
            SpawnPointUsedEvent5();
        }
        if(polaroidCount == 6)
        {
            SpawnPointUsedEvent6();
        }
    }

    IEnumerator CapturePolaroid()
    {
        itemNameText.text = "";
        PolaroidUI.SetActive(false);
        viewingPolaroid = true;
        PolaroidFrame.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        yield return new WaitForEndOfFrame();
        polaroidCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);
        polaroidCapture.ReadPixels(regionToRead, 0, 0, false);
        polaroidCapture.Apply();
        ShowPolaroid();
        InstantiatePolaroid(item);
        StartCoroutine(DropItem());
        item.gameObject.SetActive(false);
        yield return new WaitForSeconds(2.25f);
        printingAnim.Play("PolaroidPrint");
        yield return new WaitForSeconds(0.5f);
        capturingPolaroid = false;
        RemovePolaroid();
        emailAlert.SetActive(true);
        newEmailSound.Play();
        newEmailAnim.Play("EmailAlert");
        yield return new WaitForSeconds(1.75f);
        emailAlert.SetActive(false);


    }

    private void SpawnPointUsedEvent1()
    {
        items[1].SetActive(true);
        emails[1].SetActive(true);
    }

    private void SpawnPointUsedEvent2()
    {
        items[2].SetActive(true);
        emails[2].SetActive(true);
    }
    private void SpawnPointUsedEvent3()
    {
        items[3].SetActive(true);
        emails[3].SetActive(true);
    }
    private void SpawnPointUsedEvent4()
    {
        items[4].SetActive(true);
        emails[4].SetActive(true);
    }
    private void SpawnPointUsedEvent5()
    {
        items[5].SetActive(true);
        emails[5].SetActive(true);

    }
    private void SpawnPointUsedEvent6()
    {
        emails[6].SetActive(true);
    }
    void ShowPolaroid()
    {
        Sprite polaroidSprite = Sprite.Create(polaroidCapture, new Rect(0.0f, 0.0f, polaroidCapture.width, polaroidCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
        polaroidDisplayArea.sprite = polaroidSprite;
        PolaroidFrame.SetActive(true);
        StartCoroutine(PolaroidFlashEffect());
        fadingAnim.Play("PolaroidFade");
        itemNameText.text = "";
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
        examineMode = true;
        viewingPolaroid = false;
        PolaroidFrame.SetActive(false);
        polaroidInstance = null;
    }

  

   


}
