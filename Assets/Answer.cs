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
        
        // if the answer is correct
        if (result.text == QuestionGenerator.answer.ToString()) 
        {
            // switch to win screen sceen
            MissileMovement.score += 10;
            SceneManager.LoadScene(1);
        }
        else // if answer is incorrect 
        {
            // switch to lose screen sceen 
            SceneManager.LoadScene(2);
        }
    }

}
