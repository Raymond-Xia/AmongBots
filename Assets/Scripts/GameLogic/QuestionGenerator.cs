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
        a1 = GameObject.Find(Constants.ANSWER_ONE_OVERLAY).GetComponent<TMP_Text>();
        a2 = GameObject.Find(Constants.ANSWER_TWO_OVERLAY).GetComponent<TMP_Text>();
        a3 = GameObject.Find(Constants.ANSWER_THREE_OVERLAY).GetComponent<TMP_Text>();
        
        // Generate answer
        minNum = 0;
        maxNum = 10;
        X = Random.Range(minNum,maxNum);
        Y = Random.Range(minNum,maxNum);
        answer = X + Y;

        // Generate wrong answers
        Stack<int> wrongAnswers = new Stack<int>();
        for (int i = 0; i < 2; i++) {
            int rand;
            do {
                rand = Random.Range(answer-10, answer+10);
            } while (wrongAnswers.Contains(rand) || rand == answer);
            wrongAnswers.Push(rand);
        }

        // Write text to question and answer buttons
        int randomButton = Random.Range(1,4);
        question.text = X + " + " + Y + " = ?";
        a1.text = randomButton == 1 ? answer + "" : wrongAnswers.Pop() + "";
        a2.text = randomButton == 2 ? answer + "" : wrongAnswers.Pop() + "";
        a3.text = randomButton == 3 ? answer + "" : wrongAnswers.Pop() + "";
    }

}
