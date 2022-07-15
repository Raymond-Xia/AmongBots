using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float shootSpeed;
    public float moveSpeed;
    public Transform shootPos;
    public GameObject missile;
    public Collider2D col;
    public GameObject enemy;
    public int ammo;
    public Bounds missilePosition;
    public GameObject canvas;
    public int attackPattern;
    public bool isExiting;
    public Vector2 pausePoint;
    public Vector2 spawnLocation;
    public Vector2 exitLocation;
    public Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find(Constants.ENEMY_PREFAB);
        enemy.transform.SetPositionAndRotation(spawnLocation, Quaternion.identity);
        body = enemy.GetComponent<Rigidbody2D>();
        body.velocity = calculateVelocity(spawnLocation, pausePoint, moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.y < 0f || transform.position.y > Screen.height || transform.position.x > Screen.width || transform.position.x < 0) && isExiting)
        {
            Destroy(gameObject);
        }

        if (transform.position.y <= pausePoint.y + 25
        && transform.position.y >= pausePoint.x - 25
        && transform.position.x <= pausePoint.x + 25
        && transform.position.x >= pausePoint.x - 25
        && !isExiting)
        {
            isExiting = true;
            StartCoroutine(PauseAndResume(2.0f));
        }
    }

    Vector2 calculateVelocity(Vector2 currentPoint, Vector2 targetPoint, float moveSpeed)
    {
        float x  = targetPoint.x - currentPoint.x;
        float y = targetPoint.y - currentPoint.y;
        if (Mathf.Abs(x) >= Mathf.Abs(y))
        {
            y /= Mathf.Abs(x);
            x /= Mathf.Abs(x);

        }
        else
        {
            x /= Mathf.Abs(y);
            y /= Mathf.Abs(y);
        }
        return new Vector2(x * moveSpeed * Time.fixedDeltaTime, y * moveSpeed * Time.fixedDeltaTime);
    }

    IEnumerator PauseAndResume(float delay)
    {
        body.velocity = new Vector2(0, 0);

        Attack(attackPattern);

        yield return new WaitUntil(new System.Func<bool>(() => this.ammo == 0));
        yield return new WaitForSeconds(delay);
        body.velocity = calculateVelocity(pausePoint, exitLocation, moveSpeed);
        isExiting = true;
    }

    void Attack(int attackPattern)
    {
        switch(attackPattern)
        {
            case 1:
                StartCoroutine(AttackVertical.Shoot(enemy, missile, 1, ammo, shootSpeed, shootPos));
                break;
            case 2:
                StartCoroutine(AttackFan.Shoot(enemy, missile, 1, ammo, shootSpeed, shootPos));
                break;
            default:
                break;
        }
    }

    public void SetParameters(EnemyParameters e)
    {
        this.shootSpeed = e.shootSpeed;
        this.moveSpeed = e.moveSpeed;
        this.ammo = e.ammo;
        this.attackPattern = e.attackPattern;
        this.pausePoint = e.pausePoint;
        this.spawnLocation = e.spawnLocation;
        this.exitLocation = e.exitLocation;
    }

    public void EmptyAmmo()
    {
        this.ammo = 0;
    }
}
