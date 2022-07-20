using System;
using UnityEngine;
using TMPro;

public class Scores : MonoBehaviour
{
    public static void UpdateScores(TMP_Text highScoreText, string gameModeKey)
    {
        if (PlayerPrefs.HasKey(gameModeKey))
        {
            String[] topScores = PlayerPrefs.GetString(gameModeKey).Split("/n");
            string temp = "";
            for (int i = 0; i < 5; i++)
            {
                temp = temp + (i+1) + ". " + topScores[i] + "\n";
            }
            highScoreText.text = temp;
        }
        Debug.Log(gameModeKey);
    }
}
