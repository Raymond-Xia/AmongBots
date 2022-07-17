using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int enemiesPerRound;
    public int enemiesPerWave;
    public static int enemiesDespawned;
    public GameObject enemy;
    public BossController bossController;
    public Transform canvas;
    public bool bossSpawned;
    // Start is called before the first frame update
    void Start()
    {
        canvas = gameObject.transform;
        bossController = (BossController)canvas.GetComponent(typeof(BossController));
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesDespawned == enemiesPerRound && !bossSpawned) 
        {
            bossSpawned = true;
            bossController.WaitAndSpawnBoss();
        }
    }

    public void ResetRound() 
    {
        bossSpawned = false;
        enemiesDespawned = 0;
    }

    public void IncreaseDespawnCount() 
    {
        enemiesDespawned += 1;
    }

    public void SelectWave(int level) 
    {
        enemiesPerRound = 4;
        StartCoroutine(Generate2Waves_A());
    }

    int HorizontalLineSpawn_A(int spawnCount) 
    {
        for (int i = 0; i < spawnCount; i++) 
        {
            GameObject newEnemy = Instantiate(enemy, new Vector2(Screen.width / 2, Screen.height), Quaternion.identity, canvas) as GameObject;
            newEnemy.transform.SetSiblingIndex(1);
            newEnemy.SendMessage("SetParameters", 
                new EnemyParameters(30000f, 30000f, 5, Constants.CIRCLE_ATTACK, 
                new Vector2((1 + i) * Screen.width / (spawnCount + 1), 2*Screen.height / 3), 
                new Vector2((1 + i) * Screen.width / (spawnCount + 1), Screen.height), 
                new Vector2((1 + i) * Screen.width / (spawnCount + 1), Screen.height),
                Constants.PAUSE_TO_SHOOT, 1, 1
            ));
        }
        return spawnCount;
    }

    int HorizontalLineSpawn_B(int spawnCount) 
    {
        for (int i = 0; i < spawnCount; i++) 
        {
            GameObject newEnemy = Instantiate(enemy, new Vector2(Screen.width / 2, Screen.height), Quaternion.identity, canvas) as GameObject;
            newEnemy.transform.SetSiblingIndex(1);
            newEnemy.SendMessage("SetParameters", 
                new EnemyParameters(30000f, 30000f, 3, Constants.HOMING_ATTACK, 
                new Vector2(Screen.width, (4 + i)*Screen.height/6), 
                new Vector2(0, (4+i)*Screen.height/6), 
                new Vector2(Screen.width, (4 + i)*Screen.height/6),
                Constants.SHOOT_AND_FLY, 3, 1
            ));
        }
        return spawnCount;
    }

    IEnumerator Generate2Waves_A() 
    {
        enemiesPerWave = 0;
        enemiesPerWave += HorizontalLineSpawn_B(1);
        yield return new WaitUntil(new System.Func<bool>(() => enemiesDespawned == enemiesPerWave));
        enemiesPerWave += HorizontalLineSpawn_A(3);
    }

    public void Generate2Waves_B() 
    {

    }

    public void Generate2Waves_C() 
    {

    }

    public void Generate3Waves_A() 
    {

    }

    public void Generate3Waves_B() 
    {

    }

    public void Generate3Waves_C() 
    {

    }

    public void Generate4Waves_A() 
    {

    }

    public void Generate4Waves_B() 
    {

    }

    public void Generate4Waves_C() 
    {

    }

    public void Generate5Waves_A() 
    {

    }

    public void Generate5Waves_B() 
    {

    }

    public void Generate5Waves_C() 
    {

    }
}
