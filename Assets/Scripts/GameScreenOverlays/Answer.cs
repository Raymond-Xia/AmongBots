using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Answer : MonoBehaviour
{
    // store the answers and the attempts for later use
    public static Dictionary<string, string> record = new Dictionary<string, string>();

    public static void resetRecord ()
    {
        record = new Dictionary<string, string>();
    }
    public void AnswerMathQuestion()
    {
        string attempt = GetComponentInChildren<TMP_Text>().text;
        string answer = MathQuestionGenerator.answer.ToString();
        GameObject questionObject = GameObject.Find(Constants.MATH_QUESTION_PREFAB);
        AnswerQuestion(attempt, answer, questionObject);
    }

    public void AnswerCueCardQuestion()
    {
        string attempt = GameObject.Find(Constants.CARD_ANSWER_TEXT_OBJECT).GetComponent<Text>().text;
        string answer = GameObject.Find(Constants.CUE_CARD_QUESTION_PREFAB).GetComponent<CueCardQuestionGenerator>().answer;
        GameObject questionObject = GameObject.Find(Constants.CUE_CARD_QUESTION_PREFAB);
        AnswerQuestion(attempt, answer, questionObject);
    }
    
    private void AnswerQuestion(string attempt, string answer, GameObject questionObject)
    {

        // if the answer is correct, progress game
        if (attempt == answer)
        {
            // destroy boss and question
            GameObject boss = GameObject.Find(Constants.BOSS_PREFAB);
            BossAI bossAI = (BossAI) boss.GetComponent(typeof(BossAI));
            bossAI.DestroyAnimation();
            Destroy(questionObject);

            // reset record
            resetRecord();

            // increment score
            Score.score += 10;

            GameObject canvas = GameObject.Find(Constants.CANVAS_OBJECT);
            LevelController levelController = (LevelController)canvas.GetComponent(typeof(LevelController));
            PowerupController powerupController = (PowerupController)canvas.GetComponent(typeof(PowerupController));

            // Spawn a health or nuke powerup every 3 bosses
            if (Score.score % 3 == 0)
            {
                int rand = Random.Range(0, 2);
                switch (rand)
                {
                    case 0:
                        powerupController.SpawnHpPowerup();
                        break;
                    case 1:
                        if (NukeButton.nukeButton.interactable == false)
                        {
                            powerupController.SpawnNukePowerup();
                            break;
                        }
                        else
                            goto case 0;
                    default:
                        break;
                }
            }
            // start new level        
            levelController.NewLevel();
        }
        else // if answer is incorrect, lose game
        {   
            // update record to contain the question, attempt and the solution
            if (LevelController.gameMode == Constants.CUE_CARDS_GAMEMODE) {
                record.Add("question", CueCardQuestionGenerator.latestQuestion);
            }
            else {
                record.Add("question", MathQuestionGenerator.latestQuestion);
            }
            record.Add("attempt", attempt);
            record.Add("solution", answer);

            SceneManager.LoadScene(Constants.LOSE_SCENE);
        }
    }
}
