using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    public string[] sprites = new string[]
    {
        "Sprites/CrewmateBlack",
        "Sprites/CrewmateBlue",
        "Sprites/CrewmateBrown",
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
    }

    public void LeftButton()
    {
        i--;
        if (i < 0)
        {
            i = sprites.Length - 1;
        }
        UpdateSprite();
    }

    public void RightButton()
    {
        i++;
        if (i == sprites.Length)
        {
            i = 0;
        }
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        Sprite sprite = Resources.Load<Sprite>(sprites[i]);
        GameObject.Find("Crewmate").GetComponent<Image>().sprite = sprite;
    }
}
