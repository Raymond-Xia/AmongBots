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
        
        // if the answer is correct, progress game
        if (result.text == QuestionGenerator.answer.ToString()) 
        {
            // destroy boss and question
            GameObject boss = GameObject.Find(Constants.BOSS_PREFAB);
            BossAI bossAI = (BossAI) boss.GetComponent(typeof(BossAI));
            bossAI.DestroyAnimation();
            Destroy(GameObject.Find(Constants.QUESTION_PREFAB));

            // increment score
            Score.score += 10;

            // start new level
            GameObject canvas = GameObject.Find(Constants.CANVAS_OBJECT);
            LevelController levelController = (LevelController) canvas.GetComponent(typeof(LevelController));
            levelController.NewLevel();
        }
        else // if answer is incorrect, lose game
        {
            SceneManager.LoadScene(Constants.LOSE_SCENE);
        }
    }

}
