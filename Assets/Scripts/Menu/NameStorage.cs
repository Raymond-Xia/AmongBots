using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameStorage : MonoBehaviour
{
    public string theName;
    public GameObject inputField;

    public void StoreName()
    {
        theName = inputField.GetComponent<Text>().text;
        PlayerPrefs.SetString(Constants.USERNAME, theName);
    }
}
