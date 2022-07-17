using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{
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

            // increment score
            Score.score += 10;

            GameObject canvas = GameObject.Find(Constants.CANVAS_OBJECT);
            LevelController levelController = (LevelController)canvas.GetComponent(typeof(LevelController));
            PowerupController powerupController = (PowerupController)canvas.GetComponent(typeof(PowerupController));

            // Spawn health powerup every 3 bosses
            if (Score.score % 3 == 0)
            {
                powerupController.SpawnHpPowerup();
            }

            // start new level        
            levelController.NewLevel();
        }
        else // if answer is incorrect, lose game
        {
            SceneManager.LoadScene(Constants.LOSE_SCENE);
        }
    }
}
