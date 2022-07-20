using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameStorage : MonoBehaviour
{
    public string theName;
    public GameObject inputField;
    public GameObject textDisplay;

    public void StoreName()
    {
        theName = inputField.GetComponent<Text>().text;
        if (theName != "")
        {
            PlayerPrefs.SetString(Constants.USERNAME, theName);
            textDisplay.GetComponent<Text>().text = "Username: " + theName + " Saved";
        }
    }
}
