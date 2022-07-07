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
        int level = LevelController.level;
        int chooseOperator = Random.Range(0, level/5);
        string op = "";
        switch (chooseOperator) {
            case 0:
                X = Random.Range(0, 9);
                Y = Random.Range(0, 9);
                answer = X + Y;
                op = Constants.ADDITION;
                break;
            case 1:
                X = Random.Range(0, 99);
                Y = Random.Range(0, 99);
                answer = X + Y;
                op = Constants.ADDITION;
                break;
            case 2:
                X = Random.Range(0, 9);
                Y = Random.Range(0, 9);
                answer = X - Y;
                op = Constants.SUBTRACTION;
                break;
            case 3:
                X = Random.Range(0, 99);
                Y = Random.Range(0, 99);
                answer = X - Y;
                op = Constants.SUBTRACTION;
                break;
            case 4:
                X = Random.Range(0, 9);
                Y = Random.Range(0, 9);
                answer = X * Y;
                op = Constants.MULTIPLICATION;
                break;
            case 5:
                X = Random.Range(0, 99);
                Y = Random.Range(0, 99);
                answer = X * Y;
                op = Constants.MULTIPLICATION;
                break;
            case 6:
                answer = Random.Range(0, 9);
                Y = Random.Range(0, 9);
                X = answer * Y;
                op = Constants.DIVISION;
                break;
            case 7:
                answer = Random.Range(0, 99);
                Y = Random.Range(0, 1000/99);
                X = answer * Y;
                op = Constants.DIVISION;
                break;
            default:
                Y = 0;
                X = 0;
                answer = 0;
                op = Constants.ADDITION;
                break;
        }

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
        string questionText = "{0} {1} {2} = ?";
        question.text = string.Format(questionText, X, op, Y);

        int randomButton = Random.Range(1,4);
        a1.text = randomButton == 1 ? answer + "" : wrongAnswers.Pop() + "";
        a2.text = randomButton == 2 ? answer + "" : wrongAnswers.Pop() + "";
        a3.text = randomButton == 3 ? answer + "" : wrongAnswers.Pop() + "";
    }

}
