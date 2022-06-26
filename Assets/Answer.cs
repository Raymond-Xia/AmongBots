using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;

public class Answer : MonoBehaviour
{
    public TMP_Text result;

    public void AnswerQuestion()
    {
        result = GetComponentInChildren<TMP_Text>();
        if (result.text == QuestionGenerator.answer.ToString())
        {
            SceneManager.LoadScene(0);
        }
    }

}
