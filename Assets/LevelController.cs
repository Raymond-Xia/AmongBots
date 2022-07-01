using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static int level;
    public static float levelDuration = 10.0f;
    public GameObject enemy;
    public GameObject boss;
    float enemyY = 500;
    float bossY = 1600;
    Transform canvas;
    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        canvas = gameObject.transform;
        NewLevel();
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
        GameObject newEnemy = Instantiate(enemy, new Vector2(canvas.position.x, canvas.position.y + enemyY), Quaternion.identity, canvas) as GameObject;
        newEnemy.transform.SetSiblingIndex(1);
        StartCoroutine(WaitAndSpawnBoss(levelDuration));
    }

    IEnumerator WaitAndSpawnBoss(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameObject newBoss = Instantiate(boss, new Vector2(canvas.position.x, canvas.position.y + bossY), Quaternion.identity, canvas) as GameObject;
        newBoss.transform.SetSiblingIndex(1);
    }
    
}
