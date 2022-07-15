using System.Collections;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static int level;
    public static int enemiesPerRound;
    public static int gameMode;
    public BossController bossController;
    public EnemyController enemyController;
    public GameObject backButton;
    public GameObject score;
    public Transform canvas;
    public Vector3[] fixedSpawnLocations;
    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        Score.score = 0;
        canvas = gameObject.transform;
        bossController = (BossController)canvas.GetComponent(typeof(BossController));
        enemyController = (EnemyController)canvas.GetComponent(typeof(EnemyController));
        NewLevel();

        backButton = GameObject.Find(Constants.MENU_BUTTON_OVERLAY);
        backButton.transform.SetPositionAndRotation(new Vector3((Screen.width - (Screen.width / 6)), (Screen.height - (Screen.height / 10)), 0), Quaternion.identity);

        score = GameObject.Find(Constants.SCORE_OVERLAY);
        score.transform.SetPositionAndRotation(new Vector3((Screen.width / 6), Screen.height - (Screen.height / 10), 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

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
        enemyController.GenerateWave(level);
        
        StartCoroutine(bossController.WaitAndSpawnBoss());
    }
}
