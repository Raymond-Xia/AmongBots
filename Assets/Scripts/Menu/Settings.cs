using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public void ResetButton()
    {
        PlayerPrefs.SetString(Constants.SPRITE_OWNED_KEY, "000100000000");
        PlayerPrefs.SetInt(Constants.SPRITE_SELECTED_KEY, 3);
        PlayerPrefs.Save();
        Debug.Log("Reset");
    }
}
