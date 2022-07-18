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
        enemiesPerRound = 5;
        StartCoroutine(Generate2Waves_A());
    }

    int SpawnEnemiesSynchronous(int spawnCount, EnemyParameters[] e) 
    {
        for (int i = 0; i < spawnCount; i++) 
        {
            GameObject newEnemy = Instantiate(enemy, new Vector2(Screen.width / 2, Screen.height), Quaternion.identity, canvas) as GameObject;
            newEnemy.transform.SetSiblingIndex(1);
            newEnemy.SendMessage("SetParameters", e[i]);
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
        enemiesPerWave = 0;
        EnemyParameters[] e = new EnemyParameters[3];
        for (int i = 0; i < 3; i++) 
        {
            e[i] = new EnemyParameters(
                30000f, 30000f, 5, Constants.VERTICAL_ATTACK, 
                new Vector2((1 + i) * Screen.width / 4, 2*Screen.height / 3), 
                new Vector2((1 + i) * Screen.width / 4, Screen.height), 
                new Vector2((1 + i) * Screen.width / 4, Screen.height),
                Constants.PAUSE_TO_SHOOT, 0.33f, 1, 1);
        }
        enemiesPerWave += SpawnEnemiesSynchronous(3, e);
        yield return new WaitUntil(new System.Func<bool>(() => enemiesDespawned == enemiesPerWave));

        e = new EnemyParameters[2];
        for (int i = 0; i < 2; i++) 
        {
            e[i] = new EnemyParameters(30000f, 30000f, 3, Constants.FAN_ATTACK, 
                new Vector2(Screen.width/2, Screen.height*0), 
                new Vector2(Screen.width/2, Screen.height), 
                new Vector2(Screen.width/2, 5*Screen.height * 0),
                Constants.SHOOT_AND_FLY, 1, 1, 3
            );
        }
        StartCoroutine(SpawnEnemiesWithDelay(2, e));
    }

    public void Generate2Waves_B() 
    {
        enemiesPerWave = 0;
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
