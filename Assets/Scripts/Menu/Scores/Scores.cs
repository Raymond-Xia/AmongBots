using System;
using UnityEngine;
using TMPro;

public class Scores : MonoBehaviour
{
    public static void UpdateScores(TMP_Text highScoreText, string gameModeKey, string nameKey)
    {
        if ((PlayerPrefs.HasKey(gameModeKey)) && (PlayerPrefs.HasKey(nameKey)))
        {
            String[] topScores = PlayerPrefs.GetString(gameModeKey).Split("/n");
            String[] names = PlayerPrefs.GetString(nameKey).Split("/n");
            string temp = "";
            for (int i = 0; i < 5; i++)
            {
                if (topScores[i] != "0")
                {
                    temp = temp + names[i] + "   " + topScores[i] + "\n";
                }
            }
            highScoreText.text = temp;
        }
        else
        {
            highScoreText.text = "";
        }

    }
}
