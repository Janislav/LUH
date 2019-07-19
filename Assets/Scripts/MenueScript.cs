using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenueScript : MonoBehaviour
{
    public void ChangeText(string nextText)
    {
        Application.LoadLevel(nextText);
    }
}
