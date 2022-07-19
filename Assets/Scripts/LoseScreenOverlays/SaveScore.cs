using UnityEngine;
using System;

public class SaveScore : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
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
    }
}
