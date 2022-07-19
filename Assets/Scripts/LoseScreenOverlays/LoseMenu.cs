using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LoseMenu : MonoBehaviour
{
    Text breakText;
    public void Start() 
    {
        TakeABreak.breakMessage = TakeABreak.FindInActiveObject(GameObject.Find(Constants.CANVAS_OBJECT), Constants.BREAK_MESSAGE_OBJECT);
        if (TakeABreak.warning) {
            TakeABreak.Warn();
            breakText = TakeABreak.breakMessage.GetComponentInChildren<Text>();
            breakText.text = string.Format(Constants.BREAK_MESSAGE_TEXT, (int)(TakeABreak.elapsedTime/60.0f));
        }

        SaveScore();
    }

    public void PlayButton()
    {
        PlayMenu.InitializeGame();
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(Constants.MENU_SCENE);
    }

    public static void AcknowledgeWarning()
    {
        TakeABreak.Acknowledge();
    }

    public void SaveScore()
    {
        if (PlayerPrefs.HasKey(Constants.SCORES_TOPSCORES))
        {
            String[] topScores = PlayerPrefs.GetString(Constants.SCORES_TOPSCORES).Split("/n");
        
            int[] ints = Array.ConvertAll(topScores, int.Parse);
            int tempScore = Score.score;
            for (int i = 0; i < 5; i++)
            {
                if (tempScore > ints[i])
                {
                    int t = 0;
                    t = ints[i];
                    ints[i] = tempScore;
                    tempScore = t;
                }
            }
            PlayerPrefs.SetString(Constants.SCORES_TOPSCORES, string.Join("/n", ints));
        }
        else
        {
            int[] ints = { Score.score, 0, 0, 0, 0, 0 };
            PlayerPrefs.SetString(Constants.SCORES_TOPSCORES, string.Join("/n", ints));
        }
    }
}
