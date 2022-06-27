using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
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

    void Start()
    {
        UpdateSprite();
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
        PlayerMovement.hp = 5;
        MissileMovement.score = 0;
    }

    public void UpdateSprite()
    {
        int selected = 3;
        if (PlayerPrefs.HasKey("selected"))
        {
            selected = PlayerPrefs.GetInt("selected");
        }
        Sprite sprite = Resources.Load<Sprite>(sprites[selected]);
        GameObject.Find("Crewmate").GetComponent<Image>().sprite = sprite;
    }
}
