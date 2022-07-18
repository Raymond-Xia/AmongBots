using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int enemiesThisRound;
    public int enemiesPerWave;
    public int enemiesSpawned;
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
        enemiesThisRound = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesDespawned == enemiesThisRound && !bossSpawned) 
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
        enemiesThisRound = 5;
        StartCoroutine(Generate2Waves_B());
    }

    void SpawnEnemiesSynchronous(int spawnCount, EnemyParameters[] e) 
    {
        for (int i = 0; i < spawnCount; i++) 
        {
            GameObject newEnemy = Instantiate(enemy, new Vector2(Screen.width / 2, Screen.height), Quaternion.identity, canvas) as GameObject;
            newEnemy.transform.SetSiblingIndex(1);
            newEnemy.SendMessage("SetParameters", e[i]);
        }
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
                Constants.SHOOT_AND_FLY, 1, 3, 1
            ));
        }
        return spawnCount;
    }

    IEnumerator SpawnEnemiesWithDelay(int spawnCount, EnemyParameters[] e) 
    {
        int spawned = 0;
        while (spawned < spawnCount) 
        {
            GameObject newEnemy = Instantiate(enemy, new Vector2(Screen.width / 2, Screen.height), Quaternion.identity, canvas) as GameObject;
            newEnemy.transform.SetSiblingIndex(1);
            newEnemy.SendMessage("SetParameters", e[spawned]);
            yield return new WaitForSeconds(0.5f);
            spawned += 1;
        }
    }

    IEnumerator Generate2Waves_A() 
    {
        enemiesSpawned = 0;
        int enemiesThisWave = 2;
        EnemyParameters[] e = new EnemyParameters[enemiesThisWave];
        for (int i = 0; i < enemiesThisWave; i++) 
        {
            e[i] = new EnemyParameters(
                40000f, 30000f, 15, Constants.VERTICAL_ATTACK, 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), 2*Screen.height / 3), 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), Screen.height), 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), Screen.height),
                Constants.PAUSE_TO_SHOOT, 0.2f, 1, 1);
        }
        enemiesSpawned += enemiesThisWave;
        SpawnEnemiesSynchronous(enemiesThisWave, e);
        yield return new WaitUntil(new System.Func<bool>(() => enemiesDespawned == enemiesSpawned));

        enemiesThisWave = 3;
        e = new EnemyParameters[enemiesThisWave];
        for (int i = 0; i < enemiesThisWave; i++) 
        {
            e[i] = new EnemyParameters(
                40000f, 30000f, 3, Constants.FAN_ATTACK, 
                new Vector2(Screen.width, 5*Screen.height / 6), 
                new Vector2(0, 5*Screen.height / 6), 
                new Vector2(Screen.width, 5*Screen.height * 0),
                Constants.SHOOT_AND_FLY, 1, 3, 1
            );
        }
        StartCoroutine(SpawnEnemiesWithDelay(enemiesThisWave, e));
    }

    IEnumerator Generate2Waves_B() 
    {
        enemiesSpawned = 0;
        int enemiesThisWave = 2;
        EnemyParameters[] e = new EnemyParameters[enemiesThisWave];

        for (int i = 0; i < enemiesThisWave; i++) 
        {
            e[i] = new EnemyParameters(
                40000f, 30000f, 4, Constants.CIRCLE_ATTACK,
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), 2*Screen.height / 3), 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), Screen.height), 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), Screen.height),
                Constants.PAUSE_TO_SHOOT, 0.5f, 1, 1
            );
        }
        enemiesSpawned += enemiesThisWave;
        SpawnEnemiesSynchronous(enemiesThisWave, e);
        yield return new WaitUntil(new System.Func<bool>(() => enemiesDespawned == enemiesSpawned));

        enemiesThisWave = 3;
        e = new EnemyParameters[enemiesThisWave];
        for (int i = 0; i < enemiesThisWave; i++) 
        {
            e[i] = new EnemyParameters(
                40000f, 30000f, 20, Constants.HOMING_ATTACK,
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), 2*Screen.height / 3), 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), Screen.height), 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), Screen.height),
                Constants.PAUSE_TO_SHOOT, 0.2f, 1, 1
            );
        }
        SpawnEnemiesSynchronous(enemiesThisWave, e);
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
