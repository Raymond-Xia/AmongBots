using System;
using UnityEngine;
using TMPro;

public class HighScores : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UpdateScores();
    }

    public void UpdateScores()
    {
        if (PlayerPrefs.HasKey(Constants.SCORES_TOPSCORES))
        {
            String[] topScores = PlayerPrefs.GetString(Constants.SCORES_TOPSCORES).Split("/n");
            string temp = "";
            for (int i = 0; i < 5; i++)
            {
                temp = temp + (i+1) + ". " + topScores[i] + "\n";
            }
            GameObject.Find(Constants.SCORES_TEXT).GetComponent<TMP_Text>().text = temp;
        }
    }
}
