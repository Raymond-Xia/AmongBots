using System;
using UnityEngine;
using TMPro;

public class AdditionScores : MonoBehaviour
{
    public TMP_Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        highScoreText = GetComponent<TMP_Text>();
        if (PlayerPrefs.HasKey(Constants.SCORES_ADDITION_TOPSCORES))
        {
            String[] topScores = PlayerPrefs.GetString(Constants.SCORES_ADDITION_TOPSCORES).Split("/n");
            string temp = "";
            for (int i = 0; i < 5; i++)
            {
                temp = temp + (i+1) + ". " + topScores[i] + "\n";
            }
            highScoreText.text = temp;
        }
    }
}