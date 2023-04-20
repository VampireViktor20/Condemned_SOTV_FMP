using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolaroidCamera : MonoBehaviour
{
    [SerializeField] private GameObject polaroidPrefab;
    [SerializeField] private Transform spawnPoint;
    //[SerializeField] private float polaroidForce = 5f;

    private Camera mainCamera;

    private void Start()
    {
        // Get the main camera in the scene
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // Check if the space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Take a screenshot of the scene
            Texture2D screenshot = TakeScreenshot();

            // Instantiate a new polaroid prefab at the spawn point
            GameObject polaroid = Instantiate(polaroidPrefab, spawnPoint.position, Quaternion.Euler(0, 0, 90));

            // Set the polaroid's texture to the screenshot
            polaroid.GetComponent<Renderer>().material.mainTexture = screenshot;
          
     
            // Eject the polaroid from the camera with a force
            //Rigidbody rigidbody = polaroid.GetComponent<Rigidbody>();
            //rigidbody.AddForce(mainCamera.transform.forward * polaroidForce, ForceMode.Impulse);
        }
    }

    private Texture2D TakeScreenshot()
    {
        // Create a new texture with the dimensions of the screen
        Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        // Read the screen pixels into the texture
        screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshot.Apply();

        return screenshot;
    }
}
