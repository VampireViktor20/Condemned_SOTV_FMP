using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Emails")]
public class Emails : ScriptableObject
{
    public string emailName;
    [TextArea] public string emailMessage;

}
