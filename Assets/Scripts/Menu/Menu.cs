using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static string[] sprites = new string[]
    {
        Constants.BLACK_CREWMATE,
        Constants.BLUE_CREWMATE,
        Constants.BROWN_CREWMATE,
        Constants.CYAN_CREWMATE,
        Constants.GREEN_CREWMATE,
        Constants.LIME_CREWMATE,
        Constants.ORANGE_CREWMATE,
        Constants.PINK_CREWMATE,
        Constants.PURPLE_CREWMATE,
        Constants.RED_CREWMATE,
        Constants.WHITE_CREWMATE,
        Constants.YELLOW_CREWMATE
    };

    void Start()
    {
        UpdateSprite();
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(Constants.GAME_SCENE);
        PlayerMovement.hp = 5;
        Score.score = 0;
    }

    public void UpdateSprite()
    {
        int selected = 3;
        if (PlayerPrefs.HasKey(Constants.SPRITE_SELECTED_KEY))
        {
            selected = PlayerPrefs.GetInt(Constants.SPRITE_SELECTED_KEY);
        }
        Sprite sprite = Resources.Load<Sprite>(sprites[selected]);
        GameObject.Find(Constants.CREWMATE_OBJECT).GetComponent<Image>().sprite = sprite;
    }
}
