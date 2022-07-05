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
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find(Constants.ENEMY_PREFAB);
        StartCoroutine(Spawn(enemy, 5.0f));
        enemy.SetActive(true);
        StartCoroutine(Shoot(1));
        canvas = GameObject.Find(Constants.CANVAS_OBJECT);
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

    IEnumerator Shoot(float delay)
    {
        while (ammo > 0)
        {
            GameObject newMissile = Instantiate(missile, shootPos.position, Quaternion.identity) as GameObject;
            newMissile.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -shootSpeed * Time.fixedDeltaTime);
            newMissile.transform.SetParent(GameObject.Find(Constants.CANVAS_OBJECT).transform, true);
            ammo -= 1;
            yield return new WaitForSeconds(delay);
        }
    }
}
