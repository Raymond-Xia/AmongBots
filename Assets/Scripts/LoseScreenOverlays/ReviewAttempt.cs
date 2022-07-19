using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReviewAttempt : MonoBehaviour
{
    public TMP_Text displayText;

    void Start()
    {
        ShowAttempt();
    }

    void ShowAttempt()
    {
        string attempt = Answer.record["attempt"];
        displayText = GetComponentInChildren<TMP_Text>();
        displayText.text = attempt;
    }
}
