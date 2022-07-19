// using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MathQuestionGenerator : MonoBehaviour
{
    // for external use only
    public static string latestQuestion;
    public TMP_Text question;
    public TMP_Text a1;
    public TMP_Text a2;
    public TMP_Text a3;
    int X, Y;
    public static int answer;
    public Text timer;
    private float remainingTime;

    // Start is called before the first frame update
    void Start()
    {
        // Generate question
        int gameMode = LevelController.gameMode;
        int level = LevelController.level;
        int chooseDifficulty = 0;
        string op = "";
        switch (gameMode) {
            case Constants.ORIGINAL_GAMEMODE:
                chooseDifficulty = Random.Range(0, Mathf.Min(1 + level/5, 8));
                break;
            case Constants.ADDITION_GAMEMODE:
                chooseDifficulty = level < 10 ? 0 : Random.Range(0, 2);
                break;
            case Constants.SUBTRACTION_GAMEMODE:
                chooseDifficulty = level < 10 ? 2 : Random.Range(2, 4);
                break;
            case Constants.MULTIPLICATION_GAMEMODE:
                chooseDifficulty = level < 10 ? 4 : Random.Range(4, 6);
                break;
            case Constants.DIVISION_GAMEMODE:
                chooseDifficulty = level < 10 ? 6 : Random.Range(6, 8);
                break;
        }
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
        latestQuestion = question.text;

        int randomButton = Random.Range(1,4);
        a1.text = randomButton == 1 ? answer + "" : wrongAnswers.Pop() + "";
        a2.text = randomButton == 2 ? answer + "" : wrongAnswers.Pop() + "";
        a3.text = randomButton == 3 ? answer + "" : wrongAnswers.Pop() + "";
        
        // Start timer
        remainingTime = 10.00f;
        StartCoroutine(RunTimer());
    }

    private IEnumerator RunTimer()
    {
        while (remainingTime >= 0.005f) 
        {
            remainingTime -= Time.deltaTime;
            if (remainingTime <= 5.0f) timer.color = Color.red;
            timer.text = "TIME: " + remainingTime.ToString("0.00");
            yield return null;
        }
        if (remainingTime < 0.005f)
        {
            SceneManager.LoadScene(Constants.LOSE_SCENE);
        }
        
    }

}
