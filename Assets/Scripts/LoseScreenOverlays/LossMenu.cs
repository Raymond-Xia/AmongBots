using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LossMenu : MonoBehaviour
{
    Text breakText;
    public void Start() 
    {
        TakeABreak.breakMessage = TakeABreak.FindInActiveObject(GameObject.Find(Constants.CANVAS_OBJECT), Constants.BREAK_MESSAGE_OBJECT);
        TakeABreak.breakMessage.SetActive(false);
        if (TakeABreak.warning) {
            TakeABreak.Warn();
            breakText = TakeABreak.breakMessage.GetComponentInChildren<Text>();
            breakText.text = string.Format(Constants.BREAK_MESSAGE_TEXT, (int)(TakeABreak.elapsedTime/60.0f));
        }

        if (Answer.record.Count == 0)
        {
            Destroy(GameObject.Find("ReviewButton"));
        }
        
        SaveScore();
    }

    public void PlayButton()
    {
        Answer.resetRecord();
        PlayMenu.InitializeGame();
    }

    public void ExitButton()
    {
        Answer.resetRecord();
        SceneManager.LoadScene(Constants.MENU_SCENE);
    }

    public static void AcknowledgeWarning()
    {
        TakeABreak.Acknowledge();
    }

    public void SaveScore()
    {
        //specify key based on game mode
        string score_gameMode = Constants.SCORES_TOPSCORES;
        if (PlayMenu.is_CueCard)
        {
            score_gameMode = Constants.SCORES_CUECARD_TOPSCORES;
        }
        else if (PlayMenu.is_addition)
        {
            score_gameMode = Constants.SCORES_ADDITION_TOPSCORES;
        }
        else if (PlayMenu.is_subtraction)
        {
            score_gameMode = Constants.SCORES_SUBTRACTION_TOPSCORES;
        }
        else if (PlayMenu.is_multiplication)
        {
            score_gameMode = Constants.SCORES_MULTIPLICATION_TOPSCORES;
        }
        else if (PlayMenu.is_division)
        {
            score_gameMode = Constants.SCORES_DIVISION_TOPSCORES;
        }

        //update corresponding player pref with new score
        if (PlayerPrefs.HasKey(score_gameMode))
        {
            String[] topScores = PlayerPrefs.GetString(score_gameMode).Split("/n");

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
            PlayerPrefs.SetString(score_gameMode, string.Join("/n", ints));
        }
        else
        {
            int[] ints = { Score.score, 0, 0, 0, 0, 0 };
            PlayerPrefs.SetString(score_gameMode, string.Join("/n", ints));
        }

        int balance = 0;
        if (PlayerPrefs.HasKey(Constants.SCORES_BALANCE))
        {
            balance = PlayerPrefs.GetInt(Constants.SCORES_BALANCE);
        }
        PlayerPrefs.SetInt(Constants.SCORES_BALANCE, balance + Score.score);
    }
}
