using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int enemiesPerRound;
    public GameObject enemy;
    public Transform canvas;
    public Vector3[] fixedSpawnLocations;
    // Start is called before the first frame update
    void Start()
    {
        canvas = gameObject.transform;
        fixedSpawnLocations = new Vector3[] 
        {
            new Vector3(0, 2*Screen.height / 3),
            new Vector3(0, 5*Screen.height / 6, 0),
            new Vector3(0, Screen.height, 0),
            new Vector3(Screen.width / 4, Screen.height, 0),
            new Vector3(Screen.width / 2, Screen.height, 0),
            new Vector3(3*Screen.width / 4, Screen.height, 0),
            new Vector3(Screen.width, Screen.height, 0),
            new Vector3(Screen.width, 5*Screen.height / 6, 0),
            new Vector3(Screen.width, 2*Screen.height / 3, 0)
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateWave(int level) 
    {
        GameObject newEnemy = Instantiate(enemy, new Vector2(Screen.width / 2, Screen.height), Quaternion.identity, canvas) as GameObject;
        newEnemy.transform.SetSiblingIndex(1);
        newEnemy.SendMessage("SetParameters", new EnemyParameters(30000f, 30000f, 3, 2, new Vector2(Screen.width / 2, 2*Screen.height / 3), this.fixedSpawnLocations[2], this.fixedSpawnLocations[6]));
    }
}
