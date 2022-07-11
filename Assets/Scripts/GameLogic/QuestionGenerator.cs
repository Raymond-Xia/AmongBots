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
        
        // Generate question
        int level = LevelController.level;
        int chooseDifficulty = Random.Range(0, 1 + level/5);
        string op = "";
        switch (chooseDifficulty) {
            case 0: // single digit addition
                X = Random.Range(0, 9);
                Y = Random.Range(0, 9);
                answer = X + Y;
                op = Constants.ADDITION;
                break;
            case 1: // double/single digit addition
                X = Random.Range(0, 99);
                Y = Random.Range(0, 99);
                answer = X + Y;
                op = Constants.ADDITION;
                break;
            case 2: // single digit subtraction
                X = Random.Range(0, 9);
                Y = Random.Range(0, 9);
                answer = X - Y;
                op = Constants.SUBTRACTION;
                break;
            case 3: // double/single digit subtraction
                X = Random.Range(0, 99);
                Y = Random.Range(0, 99);
                answer = X - Y;
                op = Constants.SUBTRACTION;
                break;
            case 4: // single digit multiplication
                X = Random.Range(0, 9);
                Y = Random.Range(0, 9);
                answer = X * Y;
                op = Constants.MULTIPLICATION;
                break;
            case 5: // double/single digit multiplication
                X = Random.Range(1, 99);
                Y = Random.Range(0, 1000/X); // keep answers below 1000 to maintain simplicity
                answer = X * Y;
                op = Constants.MULTIPLICATION;
                break;
            case 6: // single digit division
                answer = Random.Range(0, 9);
                Y = Random.Range(1, 9);
                X = answer * Y;
                op = Constants.DIVISION;
                break;
            case 7: // double/single digit division
                answer = Random.Range(0, 99);
                Y = Random.Range(1, 1000/99); // keep answers below 1000 to maintain simplicity
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
        question.text = string.Format(Constants.QUESTION_FORMAT, X, op, Y);

        int randomButton = Random.Range(1,4);
        a1.text = randomButton == 1 ? answer + "" : wrongAnswers.Pop() + "";
        a2.text = randomButton == 2 ? answer + "" : wrongAnswers.Pop() + "";
        a3.text = randomButton == 3 ? answer + "" : wrongAnswers.Pop() + "";
    }

}
