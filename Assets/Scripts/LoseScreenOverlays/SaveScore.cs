using UnityEngine;
using System;

public class SaveScore : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        String[] topScores = PlayerPrefs.GetString("TopScores").Split("/n");
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
        PlayerPrefs.SetString("TopScores", string.Join("/n", ints));
    }
}
