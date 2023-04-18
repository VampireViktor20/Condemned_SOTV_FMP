using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EmailHandler : MonoBehaviour
{
    [SerializeField] private Emails email;
    [SerializeField] private Text emailName;
    [SerializeField] private Text emailMessage;

    [SerializeField] private Text emailNameView;
    [SerializeField] private Text emailMessageView;

    private void Awake()
    {
        emailName.text = email.emailName;
        emailMessage.text = email.emailMessage;
    }

    public void AddContent()
    {
        emailNameView.text = email.emailName;
        emailMessageView.text = email.emailMessage;
    }
}
