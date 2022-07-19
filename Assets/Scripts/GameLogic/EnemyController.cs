using System;
using System.Collections;
using System.Collections.Generic;
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
        switch(level) 
        {
            case > 30:
                if (level % 3 == 0)
                    StartCoroutine(Generate5Waves_A());
                else if (level % 3 == 1)
                    StartCoroutine(Generate5Waves_B());
                else
                    StartCoroutine(Generate5Waves_C());
                break;
            case > 20:
                if (level % 3 == 0)
                    StartCoroutine(Generate4Waves_A());
                else if (level % 3 == 1)
                    StartCoroutine(Generate4Waves_B());
                else
                    StartCoroutine(Generate4Waves_C());
                break;
            case > 10:
                if (level % 3 == 0) {
                    enemiesThisRound = 10;
                    StartCoroutine(Generate3Waves_A());
                }
                else if (level % 3 == 1) {
                    enemiesThisRound = 10;
                    StartCoroutine(Generate3Waves_B());
                }
                else {
                    enemiesThisRound = 10;
                    StartCoroutine(Generate3Waves_C());
                }
                break;
            case > 0:
                if (level % 3 == 0) {
                    enemiesThisRound = 5;
                    StartCoroutine(Generate2Waves_A());
                }
                else if (level % 3 == 1) {
                    enemiesThisRound = 5;
                    StartCoroutine(Generate2Waves_B());
                }
                else {
                    enemiesThisRound = 3;
                    StartCoroutine(Generate2Waves_C());
                }
                break;
            default:
                break;
        }
    }

    void SpawnEnemiesSynchronous(int spawnCount, EnemyParameters[] e) 
    {
        for (int i = 0; i < spawnCount; i++) 
        {
            GameObject newEnemy = Instantiate(enemy, new Vector2(Screen.width / 2, Screen.height), Quaternion.identity, canvas) as GameObject;
            newEnemy.transform.SetSiblingIndex(1);
            newEnemy.SendMessage(Constants.SET_PARAMETERS, e[i]);
        }
    }

    IEnumerator SpawnEnemiesWithDelay(int spawnCount, EnemyParameters[] e) 
    {
        int spawned = 0;
        while (spawned < spawnCount) 
        {
            GameObject newEnemy = Instantiate(enemy, new Vector2(Screen.width / 2, Screen.height), Quaternion.identity, canvas) as GameObject;
            newEnemy.transform.SetSiblingIndex(1);
            newEnemy.SendMessage(Constants.SET_PARAMETERS, e[spawned]);
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
        Debug.Log(enemiesSpawned);
        Debug.Log(enemiesDespawned == enemiesSpawned);
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

    IEnumerator Generate2Waves_C() 
    {
        enemiesSpawned = 0;
        int enemiesThisWave = 2;
        EnemyParameters[] e = new EnemyParameters[enemiesThisWave];

        for (int i = 0; i < enemiesThisWave; i++) 
        {
            e[i] = new EnemyParameters(
                40000f, 30000f, 4, Constants.RANDOM_ATTACK,
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), 2*Screen.height / 3), 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), Screen.height), 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), Screen.height),
                Constants.PAUSE_TO_SHOOT, 0.5f, 1, 1
            );
        }
        enemiesSpawned += enemiesThisWave;
        StartCoroutine(SpawnEnemiesWithDelay(enemiesThisWave, e));
        yield return new WaitUntil(new System.Func<bool>(() => enemiesDespawned == enemiesSpawned));

        enemiesThisWave = 1;
        e = new EnemyParameters[enemiesThisWave];
        for (int i = 0; i < enemiesThisWave; i++) 
        {
            e[i] = new EnemyParameters(
                40000f, 30000f, 4, Constants.SPIRAL_ATTACK,
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), 2*Screen.height / 3), 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), Screen.height), 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), Screen.height),
                Constants.PAUSE_TO_SHOOT, 0.2f, 1, 1
            );  
        }
        SpawnEnemiesSynchronous(enemiesThisWave, e);
    }

    IEnumerator Generate3Waves_A() 
    {
        enemiesSpawned = 0;
        int enemiesThisWave = 3;
        EnemyParameters[] e = new EnemyParameters[enemiesThisWave];

        for (int i = 0; i < enemiesThisWave; i++) 
        {
            e[i] = new EnemyParameters(
                40000f, 30000f, 8, Constants.HOMING_ATTACK,
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), 2*Screen.height / 3), 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), Screen.height), 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), Screen.height),
                Constants.PAUSE_TO_SHOOT, 0.25f, 1, 1
            );
        }
        enemiesSpawned += enemiesThisWave;
        SpawnEnemiesSynchronous(enemiesThisWave, e);
        yield return new WaitUntil(new System.Func<bool>(() => enemiesDespawned == enemiesSpawned));

        enemiesThisWave = 2;
        e = new EnemyParameters[enemiesThisWave];
        for (int i = 0; i < enemiesThisWave; i++) 
        {
            e[i] = new EnemyParameters(
                40000f, 30000f, 8, Constants.CIRCLE_ATTACK,
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), 2*Screen.height / 3), 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), Screen.height), 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), Screen.height),
                Constants.PAUSE_TO_SHOOT, 0.5f, 1, 1
            );  
        }
        enemiesSpawned += enemiesThisWave;
        SpawnEnemiesSynchronous(enemiesThisWave, e);
        yield return new WaitUntil(new System.Func<bool>(() => enemiesDespawned == enemiesSpawned));

        enemiesThisWave = 5;
        e = new EnemyParameters[enemiesThisWave];
        for (int i = 0; i < enemiesThisWave; i++) 
        {
            e[i] = new EnemyParameters(
                40000f, 30000f, 4, Constants.VERTICAL_AND_HOMING_ATTACK,
                new Vector2(Screen.width, 5*Screen.height / 6), 
                new Vector2(0, 5*Screen.height / 6), 
                new Vector2(Screen.width, 5*Screen.height / 6),
                Constants.SHOOT_AND_FLY, 0.2f, 4, 1
            );  
        }
        StartCoroutine(SpawnEnemiesWithDelay(enemiesThisWave, e));
    }

    IEnumerator Generate3Waves_B() 
    {
        enemiesSpawned = 0;
        int enemiesThisWave = 1;
        EnemyParameters[] e = new EnemyParameters[enemiesThisWave];

        for (int i = 0; i < enemiesThisWave; i++) 
        {
            e[i] = new EnemyParameters(
                40000f, 30000f, 4, Constants.SPIRAL_ATTACK,
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), 2*Screen.height / 3), 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), Screen.height), 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), Screen.height),
                Constants.PAUSE_TO_SHOOT, 0.2f, 1, 1
            );  
        }
        enemiesSpawned += enemiesThisWave;
        SpawnEnemiesSynchronous(enemiesThisWave, e);

        enemiesThisWave = 2;
        e = new EnemyParameters[enemiesThisWave];
        for (int i = 0; i < enemiesThisWave; i++) 
        {
            e[i] = new EnemyParameters(
                40000f, 30000f, 4, Constants.FAN_ATTACK, 
                new Vector2((1 + 2*i) * Screen.width / (enemiesThisWave + 2), 2*Screen.height / 3), 
                new Vector2((1 + 2*i) * Screen.width / (enemiesThisWave + 2), Screen.height), 
                new Vector2((1 + 2*i) * Screen.width / (enemiesThisWave + 2), Screen.height),
                Constants.PAUSE_TO_SHOOT, 0.3f, 1, 1
            );
        }
        enemiesSpawned += enemiesThisWave;
        SpawnEnemiesSynchronous(enemiesThisWave, e);
        yield return new WaitUntil(new System.Func<bool>(() => enemiesDespawned == enemiesSpawned));

        enemiesThisWave = 5;
        e = new EnemyParameters[enemiesThisWave];
        for (int i = 0; i < enemiesThisWave; i++) 
        {
            e[i] = new EnemyParameters(
                40000f, 30000f, 12, Constants.VERTICAL_ATTACK,
                new Vector2(Screen.width, 5*Screen.height / 6), 
                new Vector2(0, 5*Screen.height / 6), 
                new Vector2(Screen.width, 5*Screen.height / 6),
                Constants.SHOOT_AND_FLY, 0.2f, 16, 1
            );  
        }
        enemiesSpawned += enemiesThisWave;
        StartCoroutine(SpawnEnemiesWithDelay(enemiesThisWave, e));
        yield return new WaitUntil(new System.Func<bool>(() => enemiesDespawned == enemiesSpawned));

        enemiesThisWave = 2;
        e = new EnemyParameters[enemiesThisWave];
        for (int i = 0; i < enemiesThisWave; i++) 
        {
            e[i] = new EnemyParameters(
                40000f, 30000f, 8, Constants.CIRCLE_AND_HOMING_ATTACK,
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), 2*Screen.height / 3), 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), Screen.height), 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), Screen.height),
                Constants.PAUSE_TO_SHOOT, 0.5f, 1, 1
            );  
        }
        SpawnEnemiesSynchronous(enemiesThisWave, e);
    }

    IEnumerator Generate3Waves_C() 
    {
        enemiesSpawned = 0;
        int enemiesThisWave = 3;
        EnemyParameters[] e = new EnemyParameters[enemiesThisWave];

        for (int i = 0; i < enemiesThisWave; i++) 
        {
            e[i] = new EnemyParameters(
                40000f, 30000f, 8, Constants.RANDOM_ATTACK,
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), 2*Screen.height / 3), 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), Screen.height), 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), Screen.height),
                Constants.PAUSE_TO_SHOOT, 0.25f, 1, 1
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
                40000f, 30000f, 2, Constants.CIRCLE_ATTACK, 
                new Vector2(Screen.width / 2, 0), 
                new Vector2(Screen.width / 2, Screen.height), 
                new Vector2(Screen.width / 2, 0),
                Constants.SHOOT_AND_FLY, 1, 1, 2
            );
        }

        enemiesSpawned += enemiesThisWave;
        StartCoroutine(SpawnEnemiesWithDelay(enemiesThisWave, e));
        yield return new WaitUntil(new System.Func<bool>(() => enemiesDespawned == enemiesSpawned));

        enemiesThisWave = 2;
        e = new EnemyParameters[enemiesThisWave];
        for (int i = 0; i < enemiesThisWave; i++) 
        {
            e[i] = new EnemyParameters(
                40000f, 30000f, 6, Constants.HOMING_ATTACK,
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), 2*Screen.height / 3), 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), Screen.height), 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), Screen.height),
                Constants.PAUSE_TO_SHOOT, 0.5f, 1, 1
            );  
        }
        enemiesSpawned += enemiesThisWave;
        SpawnEnemiesSynchronous(enemiesThisWave, e);

        enemiesThisWave = 2;
        e = new EnemyParameters[enemiesThisWave];
        for (int i = 0; i < enemiesThisWave; i++) 
        {
            e[i] = new EnemyParameters(
                40000f, 60000f, 6, Constants.HOMING_ATTACK, 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), Screen.height / 3), 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), Screen.height), 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), Screen.height),
                Constants.PAUSE_TO_SHOOT, 0.5f, 1, 1
            );
        }
        SpawnEnemiesSynchronous(enemiesThisWave, e);
    }

    IEnumerator Generate4Waves_A() 
    {
        enemiesSpawned = 0;
        int enemiesThisWave = 3;
        EnemyParameters[] e = new EnemyParameters[enemiesThisWave];
        yield return new WaitUntil(new System.Func<bool>(() => enemiesDespawned == enemiesSpawned));
    }

    IEnumerator Generate4Waves_B() 
    {
        enemiesSpawned = 0;
        int enemiesThisWave = 3;
        EnemyParameters[] e = new EnemyParameters[enemiesThisWave];
        yield return new WaitUntil(new System.Func<bool>(() => enemiesDespawned == enemiesSpawned));
    }

    IEnumerator Generate4Waves_C() 
    {
        enemiesSpawned = 0;
        int enemiesThisWave = 3;
        EnemyParameters[] e = new EnemyParameters[enemiesThisWave];
        yield return new WaitUntil(new System.Func<bool>(() => enemiesDespawned == enemiesSpawned));
    }

    IEnumerator Generate5Waves_A() 
    {
        enemiesSpawned = 0;
        int enemiesThisWave = 3;
        EnemyParameters[] e = new EnemyParameters[enemiesThisWave];
        yield return new WaitUntil(new System.Func<bool>(() => enemiesDespawned == enemiesSpawned));
    }

    IEnumerator Generate5Waves_B() 
    {
        enemiesSpawned = 0;
        int enemiesThisWave = 3;
        EnemyParameters[] e = new EnemyParameters[enemiesThisWave];
        yield return new WaitUntil(new System.Func<bool>(() => enemiesDespawned == enemiesSpawned));
    }

    IEnumerator Generate5Waves_C() 
    {
        enemiesSpawned = 0;
        int enemiesThisWave = 3;
        EnemyParameters[] e = new EnemyParameters[enemiesThisWave];
        yield return new WaitUntil(new System.Func<bool>(() => enemiesDespawned == enemiesSpawned));
    }
}
