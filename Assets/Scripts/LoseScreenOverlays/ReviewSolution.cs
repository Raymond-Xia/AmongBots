using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReviewSolution : MonoBehaviour
{
    public TMP_Text displayText;

    void Start()
    {
        ShowSolution();
    }

    void ShowSolution()
    {
        string solution = Answer.record["solution"];
        displayText = GetComponentInChildren<TMP_Text>();
        displayText.text = solution;
    }

}
