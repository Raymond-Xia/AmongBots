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
        string name_gameMode = Constants.SCORES_TOPSCORES_NAMES;
        if (PlayMenu.is_CueCard)
        {
            score_gameMode = Constants.SCORES_CUECARD_TOPSCORES;
            name_gameMode = Constants.SCORES_CUECARD_TOPSCORES_NAMES;
        }
        else if (PlayMenu.is_addition)
        {
            score_gameMode = Constants.SCORES_ADDITION_TOPSCORES;
            name_gameMode = Constants.SCORES_ADDITION_TOPSCORES_NAMES;
        }
        else if (PlayMenu.is_subtraction)
        {
            score_gameMode = Constants.SCORES_SUBTRACTION_TOPSCORES;
            name_gameMode = Constants.SCORES_SUBTRACTION_TOPSCORES_NAMES;
        }
        else if (PlayMenu.is_multiplication)
        {
            score_gameMode = Constants.SCORES_MULTIPLICATION_TOPSCORES;
            name_gameMode = Constants.SCORES_MULTIPLICATION_TOPSCORES_NAMES;
        }
        else if (PlayMenu.is_division)
        {
            score_gameMode = Constants.SCORES_DIVISION_TOPSCORES;
            name_gameMode = Constants.SCORES_DIVISION_TOPSCORES_NAMES;
        }

        //update corresponding player pref with new score
        if ((PlayerPrefs.HasKey(score_gameMode))&&(PlayerPrefs.HasKey(name_gameMode)))
        {
            String[] names = PlayerPrefs.GetString(name_gameMode).Split("/n");
            String[] topScores = PlayerPrefs.GetString(score_gameMode).Split("/n");

            int[] ints = Array.ConvertAll(topScores, int.Parse);
            int tempScore = Score.score;
            String tempName = "";
            if (PlayerPrefs.HasKey(Constants.USERNAME))
            {
                tempName = PlayerPrefs.GetString(Constants.USERNAME);
            }
            else
            {
                tempName = Constants.DEFAULT_USERNAME;
            }
            
            for (int i = 0; i < 5; i++)
            {
                if (tempScore > ints[i])
                {
                    int t = 0;
                    t = ints[i];
                    ints[i] = tempScore;
                    tempScore = t;

                    String temp = "";
                    temp = names[i];
                    names[i] = tempName;
                    tempName = temp;
                    
                }
            }
            PlayerPrefs.SetString(score_gameMode, string.Join("/n", ints));
            PlayerPrefs.SetString(name_gameMode, string.Join("/n", names));
        }
        else
        {
            String tempName = "";
            if (PlayerPrefs.HasKey(Constants.USERNAME))
            {
                tempName = PlayerPrefs.GetString(Constants.USERNAME);
            }
            else
            {
                tempName = Constants.DEFAULT_USERNAME;
            }

            int[] ints = { Score.score, 0, 0, 0, 0};
            PlayerPrefs.SetString(score_gameMode, string.Join("/n", ints));

            String[] names = { tempName, "", "", "", ""};
            PlayerPrefs.SetString(name_gameMode, string.Join("/n", names));
        }

        if (!PlayMenu.is_CueCard)
        {
            int balance = 0;
            if (PlayerPrefs.HasKey(Constants.SCORES_BALANCE))
            {
                balance = PlayerPrefs.GetInt(Constants.SCORES_BALANCE);
            }
            PlayerPrefs.SetInt(Constants.SCORES_BALANCE, balance + Score.score);
        }
    }
}
