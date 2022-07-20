using System;
using UnityEngine;
using TMPro;

public class CueCardScores : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Scores.UpdateScores(GetComponent<TMP_Text>(), Constants.SCORES_CUECARD_TOPSCORES);
    }

    public void UpdateScores()
    {
        Scores.UpdateScores(GetComponent<TMP_Text>(), Constants.SCORES_CUECARD_TOPSCORES);
    }
}

