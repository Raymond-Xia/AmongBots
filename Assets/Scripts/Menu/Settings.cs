using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public void ResetButton()
    {
        PlayerPrefs.SetString("owned", "000100000000");
        PlayerPrefs.SetInt("selected", 3);
        PlayerPrefs.Save();
        Debug.Log("Reset");
    }
}
