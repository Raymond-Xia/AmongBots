using System;
using UnityEngine;
using TMPro;

public class OriginalScores : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Scores.UpdateScores(GetComponent<TMP_Text>(), Constants.SCORES_TOPSCORES, Constants.SCORES_TOPSCORES_NAMES);
    }

    public void UpdateScores()
    {
        Scores.UpdateScores(GetComponent<TMP_Text>(), Constants.SCORES_TOPSCORES, Constants.SCORES_TOPSCORES_NAMES);
    }
}
