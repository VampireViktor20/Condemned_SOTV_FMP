using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PrintedText : MonoBehaviour
{
    public float typingSpeed = 0.0f;
    public Text textBox;
    private StringBuilder stringBuilder = new StringBuilder();
    public AudioSource typing;
    public bool isTypingFished = false;

    void Start()
    {
        typing.Play();
        StartCoroutine(TypeText(textBox.text));
    }
    public IEnumerator TypeText(string text)
    {
        stringBuilder.Clear();

        for (int i = 0; i < text.Length; i++)
        {
            stringBuilder.Append(text[i]);
            textBox.text = stringBuilder.ToString();
            yield return new WaitForSeconds(typingSpeed);
         
        }
        isTypingFished = true;
        typing.Stop();

    }
}
