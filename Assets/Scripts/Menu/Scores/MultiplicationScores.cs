using System;
using UnityEngine;
using TMPro;

public class MultiplicationScores : MonoBehaviour
{
    public TMP_Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        highScoreText = GetComponent<TMP_Text>();
        if (PlayerPrefs.HasKey(Constants.SCORES_MULTIPLICATION_TOPSCORES))
        {
            String[] topScores = PlayerPrefs.GetString(Constants.SCORES_MULTIPLICATION_TOPSCORES).Split("/n");
            string temp = "";
            for (int i = 0; i < 5; i++)
            {
                temp = temp + (i+1) + ". " + topScores[i] + "\n";
            }
            highScoreText.text = temp;
        }
    }
}
