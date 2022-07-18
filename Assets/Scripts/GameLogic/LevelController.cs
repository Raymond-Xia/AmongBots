using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static int level;
    public static int enemiesPerRound;
    public static int gameMode;
    public static List<KeyValuePair<string, string>> usedCueCards;
    public BossController bossController;
    public EnemyController enemyController;
    public GameObject pauseButton;
    public GameObject score;
    public Transform canvas;
    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        Score.score = 0;
        canvas = gameObject.transform;
        enemyController = (EnemyController)canvas.GetComponent(typeof(EnemyController));
        NewLevel();
        usedCueCards = new List<KeyValuePair<string, string>>();
        
        pauseButton = GameObject.Find(Constants.PAUSE_BUTTON_OVERLAY);
        pauseButton.transform.SetPositionAndRotation(new Vector3((Screen.width - (Screen.width / 6)), (Screen.height - (Screen.height / 10)), 0), Quaternion.identity);

        score = GameObject.Find(Constants.SCORE_OVERLAY);
        score.transform.SetPositionAndRotation(new Vector3((Screen.width / 6), Screen.height - (Screen.height / 10), 0), Quaternion.identity);
    }

    public void NewLevel()
    {
        float delay = level == 0 ? 0.5f : 2.0f; // delay enemies appearance -- need this to stall for Boss's explosion animation!
        StartCoroutine(WaitAndStartLevel(delay));
    }

    IEnumerator WaitAndStartLevel(float delay)
    {
        yield return new WaitForSeconds(delay);
        level += 1;
        enemyController.ResetRound();
        enemyController.SelectWave(level);
    }
}
