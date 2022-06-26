using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class QuestionGenerator : MonoBehaviour
{
    public TMP_Text question;
    public TMP_Text a1;
    public TMP_Text a2;
    public TMP_Text a3;
    public int minNum, maxNum;
    public int X, Y;
    public static int answer;

    // Start is called before the first frame update
    void Start()
    {
        // Find question and answer components
        question = GetComponent<TMP_Text>();
        a1 = GameObject.Find("A1Text").GetComponent<TMP_Text>();
        a2 = GameObject.Find("A2Text").GetComponent<TMP_Text>();
        a3 = GameObject.Find("A3Text").GetComponent<TMP_Text>();
        
        // Generate answer
        minNum = 0;
        maxNum = 10;
        X = Random.Range(minNum,maxNum);
        Y = Random.Range(minNum,maxNum);
        answer = X + Y;

        // Generate wrong answers
        int wrongAnswer1;
        int wrongAnswer2;
        int wrongAnswer3;
        do {
            wrongAnswer1 = Random.Range(answer-10, answer+10);
            wrongAnswer2 = Random.Range(answer-10, answer+10);
            wrongAnswer3 = Random.Range(answer-10, answer+10);
        } while (wrongAnswer1 == answer || wrongAnswer2 == answer || wrongAnswer3 == answer 
            && wrongAnswer1 == wrongAnswer2 || wrongAnswer1 == wrongAnswer3 || wrongAnswer2 == wrongAnswer3);

        // Write text to question and answer buttons
        int randomButton = Random.Range(1,4);
        question.text = X + " + " + Y + " = ?";
        a1.text = randomButton == 1 ? answer + "" : wrongAnswer1 + "";
        a2.text = randomButton == 2 ? answer + "" : wrongAnswer2 + "";
        a3.text = randomButton == 3 ? answer + "" : wrongAnswer3 + "";
    }

}
