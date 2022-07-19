using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReviewQuestion : MonoBehaviour
{
    public TMP_Text displayText;

    void Start()
    {
        ShowQuestion();
    }

    void ShowQuestion()
    {
        string question = Answer.record["question"];
        displayText = GetComponentInChildren<TMP_Text>();
        displayText.text = question;
    }

}
