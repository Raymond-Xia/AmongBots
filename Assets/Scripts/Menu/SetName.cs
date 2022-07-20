using System;
using UnityEngine;
using TMPro;

public class SetName : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        setName();
    }

    public void setName()
    {
         if (PlayerPrefs.HasKey(Constants.USERNAME))
        {
            String name = PlayerPrefs.GetString(Constants.USERNAME);
            name = name.Substring(0,4);
            GameObject.Find(Constants.USERNAME_TEXT).GetComponent<TMP_Text>().text = name;
        }
    }

}
