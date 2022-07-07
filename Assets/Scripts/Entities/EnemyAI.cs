using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float shootSpeed;
    public Transform shootPos;
    public GameObject missile;
    public Collider2D col;
    public GameObject enemy;
    public int ammo;
    public Bounds missilePosition;
    public GameObject canvas;
    public int attackPattern;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find(Constants.ENEMY_PREFAB);
        StartCoroutine(Spawn(enemy, 5.0f));
        enemy.SetActive(true);
        if (attackPattern == 1)
        {
            StartCoroutine(AttackVertical.Shoot(missile, 1, ammo, shootSpeed, shootPos));
        }
        else if (attackPattern == 2)
        {
            StartCoroutine(AttackFan.Shoot(missile, 1, ammo, shootSpeed, shootPos));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Spawn(GameObject go, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    public void SetAttackPattern(int attackPattern) 
    {
        this.attackPattern = attackPattern;
    }
}
