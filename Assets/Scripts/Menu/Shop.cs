using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{

    public static string[] sprites = new string[]
    {
        "Sprites/CrewmateBlack",
        "Sprites/CrewmateBlue",
        "Sprites/CrewmateBrown",
        "Sprites/CrewmateCyan",
        "Sprites/CrewmateGreen",
        "Sprites/CrewmateLime",
        "Sprites/CrewmateOrange",
        "Sprites/CrewmatePink",
        "Sprites/CrewmatePurple",
        "Sprites/CrewmateRed",
        "Sprites/CrewmateWhite",
        "Sprites/CrewmateYellow"
    };

    public int i = 0;

    void Start()
    {
        i = 0;
        UpdateSprite();
        UpdateButton();
    }

    public void UpdateStart()
    {
        i = 0;
        UpdateSprite();
        UpdateButton();
    }

    public void LeftButton()
    {
        i--;
        if (i < 0)
        {
            i = sprites.Length - 1;
        }
        UpdateSprite();
        UpdateButton();
    }

    public void RightButton()
    {
        i++;
        if (i == sprites.Length)
        {
            i = 0;
        }
        UpdateSprite();
        UpdateButton();
    }

    public void BuyButton()
    {
        char[] owned = "000000000000".ToCharArray();
        if (PlayerPrefs.HasKey("owned"))
        {
            owned = PlayerPrefs.GetString("owned").ToCharArray();
        }
        owned[i] = '1';
        PlayerPrefs.SetString("owned", new string(owned));
        PlayerPrefs.Save();
        UpdateButton();
    }

    private void UpdateSprite()
    {
        Sprite sprite = Resources.Load<Sprite>(sprites[i]);
        GameObject.Find("Crewmate").GetComponent<Image>().sprite = sprite;
    }

    private void UpdateButton()
    {
        char[] owned = "000000000000".ToCharArray();
        if (PlayerPrefs.HasKey("owned"))
        {
            owned = PlayerPrefs.GetString("owned").ToCharArray();
        }
        if (owned[i].Equals('1'))
        {
            GameObject.Find("BuyButton").GetComponent<Button>().interactable = false;
            GameObject.Find("BuyText").GetComponent<TMP_Text>().text = "OWNED";
        }
        else
        {
            GameObject.Find("BuyButton").GetComponent<Button>().interactable = true;
            GameObject.Find("BuyText").GetComponent<TMP_Text>().text = "BUY";
        }
    }

}
