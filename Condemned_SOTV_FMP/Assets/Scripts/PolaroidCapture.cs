using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PolaroidCapture : MonoBehaviour
{
    [Header("Polaroid Added")]
    [SerializeField] public Image polaroidDisplayArea;
    [SerializeField] public GameObject PolaroidFrame;
    [SerializeField] public GameObject PolaroidUI;

    [Header("Polaroid FLash")]
    [SerializeField] public GameObject PolaroidFlash;
    [SerializeField] public float flashDuration;

    [Header("Polaroid Fader Effect")]
    [SerializeField] public Animator fadingAnim;

    [Header("Polaroid Sound")]
    [SerializeField] public AudioSource polaroidSound;

    private Texture2D polaroidCapture;
    public bool viewingPolaroid;

    public void Start()
    {
        polaroidCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
    }

    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(!viewingPolaroid)
            {
                StartCoroutine(CapturePolaroid());
            }
            else
            {
                RemovePolaroid();
            }
           
        }
    }

    public IEnumerator CapturePolaroid()
    {
        PolaroidUI.SetActive(false);
        viewingPolaroid = true;

        yield return new WaitForEndOfFrame();

        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);

        polaroidCapture.ReadPixels(regionToRead, 0, 0, false);
        polaroidCapture.Apply();
        ShowPolaroid();
    }

   public void ShowPolaroid()
    {
        Sprite polaroidSprite = Sprite.Create(polaroidCapture, new Rect(0.0f, 0.0f, polaroidCapture.width, polaroidCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
        polaroidDisplayArea.sprite = polaroidSprite;

        PolaroidFrame.SetActive(true);
        StartCoroutine(PolaroidFlashEffect());
        fadingAnim.Play("PolaroidFade");
    }

    public IEnumerator PolaroidFlashEffect()
    {
        polaroidSound.Play();
        PolaroidFlash.SetActive(true);
        yield return new WaitForSeconds(flashDuration);
        PolaroidFlash.SetActive(false);
    }

   public void RemovePolaroid()
    {
        viewingPolaroid = false;
        PolaroidFrame.SetActive(false);
        PolaroidUI.SetActive(true);
    }
}
