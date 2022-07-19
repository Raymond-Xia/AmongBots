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
    public GameObject player;
    public GameObject enemy;
    public BossController bossController;
    public Transform canvas;
    public bool bossSpawned;
    public List<Vector2> fixedSpawnLocations;
    public List<Vector2> fixedExitLocations;
    // Start is called before the first frame update
    void Start()
    {
        canvas = gameObject.transform;
        bossController = (BossController)canvas.GetComponent(typeof(BossController));
        player = GameObject.Find(Constants.PLAYER_OBJECT);
        enemiesThisRound = 1;

        for (int i = 0; i <= 12; i++) 
        {
            fixedSpawnLocations.Add(new Vector2(0, i * Screen.height / 12));
            fixedSpawnLocations.Add(new Vector2(i * Screen.width / 12, Screen.height));
            fixedExitLocations.Add(new Vector2(Screen.width, Screen.height - (i * Screen.height / 12)));
            fixedExitLocations.Add(new Vector2(Screen.width - (i * Screen.width / 12), 0));
        }
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
            case > 20:
                if (level % 3 == 0) {
                    enemiesThisRound = 24;
                    StartCoroutine(Generate4Waves_A());
                }
                else if (level % 3 == 1) {
                    enemiesThisRound = 14;
                    StartCoroutine(Generate4Waves_B());
                }
                else {
                    enemiesThisRound = 35;
                    StartCoroutine(Generate4Waves_C());
                }
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
        int enemiesThisWave = 24;
        EnemyParameters[] e = new EnemyParameters[enemiesThisWave];

        for (int i = 0; i < enemiesThisWave; i++) 
        {
            System.Random r1 = new System.Random();
            int pointPair = r1.Next(0, 13);

            System.Random r2 = new System.Random();
            int forwards = r2.Next(0, 2);

            if (forwards == 1) 
            {
                e[i] = new EnemyParameters(
                    40000f, 60000f, 1, Constants.NO_ATTACK, 
                    fixedExitLocations[pointPair], 
                    fixedSpawnLocations[pointPair], 
                    fixedExitLocations[pointPair],
                    Constants.SHOOT_AND_FLY, 1, 1, 1
                );
            }
            else 
            {
                e[i] = new EnemyParameters(
                    40000f, 60000f, 1, Constants.NO_ATTACK, 
                    fixedSpawnLocations[pointPair], 
                    fixedExitLocations[pointPair], 
                    fixedSpawnLocations[pointPair],
                    Constants.SHOOT_AND_FLY, 1, 1, 1
                );
            }
        }
        enemiesSpawned += enemiesThisWave;
        StartCoroutine(SpawnEnemiesWithDelay(enemiesThisWave, e));
        yield return new WaitUntil(new System.Func<bool>(() => enemiesDespawned == enemiesSpawned));
    }

    IEnumerator Generate4Waves_B() 
    {
        enemiesSpawned = 0;
        int enemiesThisWave = 5;
        EnemyParameters[] e = new EnemyParameters[enemiesThisWave];

        for (int i = 0; i < enemiesThisWave; i++) 
        {
            e[i] = new EnemyParameters(
                40000f, 30000f, 12, Constants.VERTICAL_ATTACK, 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), 2*Screen.height / 3), 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), Screen.height), 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), Screen.height),
                Constants.PAUSE_TO_SHOOT, 0.25f, 1, 1
            );
        }

        System.Random r = new System.Random();
        int specialEnemy = r.Next(0, enemiesThisWave);
        e[specialEnemy] = new EnemyParameters(
            40000f, 30000f, 0, Constants.NO_ATTACK, 
            new Vector2((1 + specialEnemy) * Screen.width / (enemiesThisWave + 1), 2*Screen.height / 3), 
            new Vector2((1 + specialEnemy) * Screen.width / (enemiesThisWave + 1), Screen.height), 
            new Vector2((1 + specialEnemy) * Screen.width / (enemiesThisWave + 1), Screen.height),
            Constants.PAUSE_TO_SHOOT, 0.5f, 1, 1
        );
        enemiesSpawned += enemiesThisWave;
        SpawnEnemiesSynchronous(enemiesThisWave, e);
        yield return new WaitUntil(new System.Func<bool>(() => enemiesDespawned == enemiesSpawned));

        enemiesThisWave = 3;
        e = new EnemyParameters[enemiesThisWave];

        for (int i = 0; i < enemiesThisWave; i++) 
        {
            e[i] = new EnemyParameters(
                40000f, 30000f, 6, Constants.FAN_AND_HOMING_ATTACK, 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), 2*Screen.height / 3), 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), Screen.height), 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), Screen.height),
                Constants.PAUSE_TO_SHOOT, 1f, 1, 1
            );
        }

        enemiesSpawned += enemiesThisWave;
        SpawnEnemiesSynchronous(enemiesThisWave, e);
        yield return new WaitUntil(new System.Func<bool>(() => enemiesDespawned == enemiesSpawned));

        enemiesThisWave = 5;
        int j = 0;
        while (j < 5)
        {
            e = new EnemyParameters[1];
            e[0] = new EnemyParameters(
                80000f, 60000f, 160, Constants.VERTICAL_ATTACK, 
                new Vector2(player.transform.position.x, 2*Screen.height / 3), 
                new Vector2(player.transform.position.x, Screen.height), 
                new Vector2(player.transform.position.x, Screen.height),
                Constants.PAUSE_TO_SHOOT, 0.01f, 1, 1
            );
            SpawnEnemiesSynchronous(1, e);
            yield return new WaitForSeconds(1f);
            j += 1;
        }

        enemiesSpawned += enemiesThisWave;
        yield return new WaitUntil(new System.Func<bool>(() => enemiesDespawned == enemiesSpawned));

        enemiesThisWave = 1;
        e = new EnemyParameters[enemiesThisWave];
        for (int i = 0; i < enemiesThisWave; i++) 
        {
            e[i] = new EnemyParameters(
                80000f, 30000f, 4, Constants.SPIRAL_AND_HOMING_ATTACK,
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), 2*Screen.height / 3), 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), Screen.height), 
                new Vector2((1 + i) * Screen.width / (enemiesThisWave + 1), Screen.height),
                Constants.PAUSE_TO_SHOOT, 1f, 1, 1
            );
        }
        SpawnEnemiesSynchronous(1, e);
    }

    IEnumerator Generate4Waves_C() 
    {
        enemiesSpawned = 0;
        int enemiesThisWave = 2;
        EnemyParameters[] e = new EnemyParameters[enemiesThisWave];

        for (int i = 0; i < enemiesThisWave; i++) 
        {
            e[i] = new EnemyParameters(
                80000f, 30000f, 500, Constants.VERTICAL_ATTACK, 
                new Vector2((1 + 4*i) * Screen.width / 6, 11*Screen.height / 12), 
                new Vector2((1 + 4*i) * Screen.width / 6, Screen.height), 
                new Vector2((1 + 4*i) * Screen.width / 6, Screen.height),
                Constants.PAUSE_TO_SHOOT, 0.01f, 1, 1
            );
        }
        enemiesSpawned += enemiesThisWave;
        SpawnEnemiesSynchronous(enemiesThisWave, e);

        enemiesThisWave = 1;
        e = new EnemyParameters[]{new EnemyParameters(
            80000f, 30000f, 8, Constants.CIRCLE_AND_HOMING_ATTACK, 
            new Vector2(Screen.width / 2, 2*Screen.height / 3), 
            new Vector2(Screen.width / 2, Screen.height), 
            new Vector2(Screen.width / 2, Screen.height),
            Constants.PAUSE_TO_SHOOT, 0.5f, 1, 1
        )};
        enemiesSpawned += enemiesThisWave;
        SpawnEnemiesSynchronous(enemiesThisWave, e);

        yield return new WaitUntil(new System.Func<bool>(() => enemiesDespawned == enemiesSpawned));

        enemiesThisWave = 4;
        e = new EnemyParameters[enemiesThisWave];
        for (int i = 0; i < 2; i++) 
        {
            e[i] = new EnemyParameters(
                80000f, 30000f, 500, Constants.VERTICAL_ATTACK, 
                new Vector2((1 + i) * Screen.width / 7, 11*Screen.height / 12), 
                new Vector2((1 + i) * Screen.width / 7, Screen.height), 
                new Vector2((1 + i) * Screen.width / 7, Screen.height),
                Constants.PAUSE_TO_SHOOT, 0.01f, 1, 1
            );
        }
        for (int i = 3; i <= enemiesThisWave; i++) 
        {
            e[i-1] = new EnemyParameters(
                80000f, 30000f, 500, Constants.VERTICAL_ATTACK, 
                new Vector2((2 + i) * Screen.width / 7, 11*Screen.height / 12), 
                new Vector2((2 + i) * Screen.width / 7, Screen.height), 
                new Vector2((2 + i) * Screen.width / 7, Screen.height),
                Constants.PAUSE_TO_SHOOT, 0.01f, 1, 1
            );
        }
        enemiesSpawned += enemiesThisWave;
        SpawnEnemiesSynchronous(enemiesThisWave, e);

        yield return new WaitForSeconds(1.5f);

        enemiesThisWave = 8;
        e = new EnemyParameters[enemiesThisWave];
        for (int i = 0; i < enemiesThisWave; i++) 
        {
            System.Random r1 = new System.Random();
            int pointPair = r1.Next(0, 6);

            System.Random r2 = new System.Random();
            int forwards = r2.Next(0, 2);

            if (forwards == 1) 
            {
                e[i] = new EnemyParameters(
                    40000f, 60000f, 1, Constants.NO_ATTACK, 
                    fixedExitLocations[pointPair * 2], 
                    fixedSpawnLocations[pointPair * 2], 
                    fixedExitLocations[pointPair * 2],
                    Constants.SHOOT_AND_FLY, 1, 1, 1
                );
            }
            else 
            {
                e[i] = new EnemyParameters(
                    40000f, 60000f, 1, Constants.NO_ATTACK, 
                    fixedSpawnLocations[pointPair * 2], 
                    fixedExitLocations[pointPair * 2], 
                    fixedSpawnLocations[pointPair * 2],
                    Constants.SHOOT_AND_FLY, 1, 1, 1
                );
            }
        }
        enemiesSpawned += enemiesThisWave;
        StartCoroutine(SpawnEnemiesWithDelay(enemiesThisWave, e));
        yield return new WaitUntil(new System.Func<bool>(() => enemiesDespawned == enemiesSpawned));

        enemiesThisWave = 2;
        e = new EnemyParameters[enemiesThisWave];
        for (int i = 0; i < enemiesThisWave; i++) 
        {
            e[i] = new EnemyParameters(
                40000f, 30000f, 5, Constants.CIRCLE_ATTACK, 
                new Vector2((1 + 4*i) * Screen.width / 6, 5* Screen.height / 6), 
                new Vector2((1 + 4*i) * Screen.width / 6, Screen.height), 
                new Vector2((1 + 4*i) * Screen.width / 6, Screen.height),
                Constants.PAUSE_TO_SHOOT, 0.8f, 1, 1
            );
        }
        enemiesSpawned += enemiesThisWave;
        SpawnEnemiesSynchronous(enemiesThisWave, e);

        e = new EnemyParameters[enemiesThisWave];
        for (int i = 0; i < enemiesThisWave; i++) 
        {
            e[i] = new EnemyParameters(
                40000f, 30000f, 5, Constants.HOMING_ATTACK, 
                new Vector2((1 + 4*i) * Screen.width / 6, Screen.height / 6), 
                new Vector2((1 + 4*i) * Screen.width / 6, 0), 
                new Vector2((1 + 4*i) * Screen.width / 6, 0),
                Constants.PAUSE_TO_SHOOT, 0.8f, 1, 1
            );
        }
        enemiesSpawned += enemiesThisWave;
        SpawnEnemiesSynchronous(enemiesThisWave, e);
        yield return new WaitUntil(new System.Func<bool>(() => enemiesDespawned == enemiesSpawned));

        enemiesThisWave = 16;
        e = new EnemyParameters[enemiesThisWave];
        for (int i = 0; i < enemiesThisWave; i++) 
        {
            System.Random r1 = new System.Random();
            int pointPair = r1.Next(0, 13);

            System.Random r2 = new System.Random();
            int forwards = r2.Next(0, 2);
            Vector2 pausePoint = new Vector2(0,0);
            if (forwards == 1) 
            {
                
                if (fixedSpawnLocations[pointPair].x == 0) 
                {
                    pausePoint = new Vector2(Screen.width / 6, fixedSpawnLocations[pointPair].y);
                }
                else if (fixedSpawnLocations[pointPair].y == Screen.height) 
                {
                    pausePoint = new Vector2(fixedSpawnLocations[pointPair].x, 5*Screen.height / 6);
                }

                e[i] = new EnemyParameters(
                    40000f, 60000f, 1, Constants.RANDOM_AND_HOMING_ATTACK, 
                    pausePoint, 
                    fixedSpawnLocations[pointPair], 
                    fixedSpawnLocations[pointPair],
                    Constants.PAUSE_TO_SHOOT, 1, 1, 1
                );
            }
            else 
            {
                if (fixedExitLocations[pointPair].x == Screen.width) 
                {
                    pausePoint = new Vector2(5 * Screen.width / 6, fixedExitLocations[pointPair].y);
                }
                else if (fixedSpawnLocations[pointPair].y == 0) 
                {
                    pausePoint = new Vector2(fixedExitLocations[pointPair].x, Screen.height / 6);
                }
                e[i] = new EnemyParameters(
                    40000f, 60000f, 1, Constants.RANDOM_AND_HOMING_ATTACK, 
                    pausePoint, 
                    fixedExitLocations[pointPair], 
                    fixedExitLocations[pointPair],
                    Constants.PAUSE_TO_SHOOT, 1, 1, 1
                );
            }
        }
        enemiesSpawned += enemiesThisWave;
        StartCoroutine(SpawnEnemiesWithDelay(enemiesSpawned, e));
        yield return new WaitUntil(new System.Func<bool>(() => enemiesDespawned == enemiesSpawned));
    }
}
