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
    public GameObject player;
    public int ammo;
    public Bounds missilePosition;
    public Transform canvas;
    public int attackPattern;
    public bool isExiting;
    public Vector2 pausePoint;
    public Vector2 spawnLocation;
    public Vector2 exitLocation;
    public int shootBehaviour;
    public float shootDelay;
    public Rigidbody2D body;
    public EnemyController enemyController;
    public int xPartition;
    public int yPartition;
    public int xIncrement;
    public int yIncrement;
    public static AudioSource laserSound;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find(Constants.CANVAS_OBJECT).transform;
        player = GameObject.Find(Constants.PLAYER_OBJECT);
        enemyController = (EnemyController)canvas.GetComponent(typeof(EnemyController));
        transform.SetPositionAndRotation(spawnLocation, Quaternion.identity);
        laserSound = GetComponent<AudioSource>();
        body = GetComponent<Rigidbody2D>();
        body.velocity = calculateVelocity(spawnLocation, pausePoint, moveSpeed);
        xIncrement = 1;
        yIncrement = 1;   
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.y < 0f || transform.position.y > Screen.height || transform.position.x > Screen.width || transform.position.x < 0) && isExiting)
        {
            enemyController.IncreaseDespawnCount();
            Destroy(gameObject);
        }

        switch(shootBehaviour) 
        {
            case Constants.PAUSE_TO_SHOOT:
                if (checkBoundingBox(pausePoint) && !isExiting)
                {
                    isExiting = true;
                    StartCoroutine(PauseAndResume(2.0f));
                }
                break;
            case Constants.SHOOT_AND_FLY:
                (xIncrement, yIncrement, ammo) = ShootAndFly(xPartition, yPartition, attackPattern, ammo, xIncrement, yIncrement, spawnLocation, exitLocation);
                break;
            default:
                break;
        }
    }

    bool checkBoundingBox(Vector2 point) 
    {
        return transform.position.y <= point.y + 25 && transform.position.y >= point.y - 25 && transform.position.x <= point.x + 25 && transform.position.x >= point.x - 25;
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

    (int, int, int) ShootAndFly(int xPartition, int yPartition, int attackPattern, int ammo, int xIncrement, int yIncrement, Vector2 spawnLocation, Vector2 exitLocation) 
    {
        float x = spawnLocation.x >= exitLocation.x ? xIncrement * Screen.width / (xPartition + 1) : Screen.width - (xIncrement * Screen.width / (xPartition + 1));
        float y = spawnLocation.y >= exitLocation.y ? Screen.height - (yIncrement * Screen.height / (yPartition + 1)) : yIncrement * Screen.height / (yPartition + 1);
        
        if (xPartition == 1) 
        {
            x = transform.position.x;
        }
        if (yPartition == 1) 
        {
            y = transform.position.y;
        }
        if (checkBoundingBox(new Vector2(x, y)) && ammo > 0) 
        {
            isExiting = true;
            xIncrement += 1;
            yIncrement += 1;
            ammo -= 1;
            switch(attackPattern) 
            {
                case Constants.VERTICAL_ATTACK:
                    AttackVertical.ShootOnDemand(enemy, missile, shootSpeed, shootPos);
                    break;
                case Constants.FAN_ATTACK:
                    AttackFan.ShootOnDemand(enemy, missile, shootSpeed, shootPos);
                    break;
                case Constants.HOMING_ATTACK:
                    AttackHoming.ShootOnDemand(enemy, missile, shootSpeed, shootPos, player.transform);
                    break;
                case Constants.CIRCLE_ATTACK:
                    AttackCircle.ShootOnDemand(enemy, missile, shootSpeed, shootPos, 0);
                    break;
                case Constants.RANDOM_ATTACK:
                    AttackRandom.ShootOnDemand(enemy, missile, shootSpeed, shootPos);
                    break;
                case Constants.VERTICAL_AND_HOMING_ATTACK:
                    AttackVertical.ShootOnDemand(enemy, missile, shootSpeed, shootPos);
                    goto case Constants.HOMING_ATTACK;
                case Constants.FAN_AND_HOMING_ATTACK:
                    AttackFan.ShootOnDemand(enemy, missile, shootSpeed, shootPos);
                    goto case Constants.HOMING_ATTACK;
                case Constants.CIRCLE_AND_HOMING_ATTACK:
                    AttackCircle.ShootOnDemand(enemy, missile, shootSpeed, shootPos, 0);
                    goto case Constants.HOMING_ATTACK;
                case Constants.RANDOM_AND_HOMING_ATTACK:
                    AttackRandom.ShootOnDemand(enemy, missile, shootSpeed, shootPos);
                    goto case Constants.HOMING_ATTACK;
                default:
                    break;
            }
        }
        return (xIncrement, yIncrement, ammo);
    }

    IEnumerator PauseAndResume(float delay)
    {
        body.velocity = new Vector2(0, 0);

        AttackInWaves(attackPattern);

        yield return new WaitUntil(new System.Func<bool>(() => this.ammo == 0));
        yield return new WaitForSeconds(delay);
        body.velocity = calculateVelocity(pausePoint, exitLocation, moveSpeed);
    }

    void AttackInWaves(int attackPattern)
    {
        switch(attackPattern)
        {
            case Constants.VERTICAL_ATTACK:
                StartCoroutine(AttackVertical.ShootInWaves(enemy, missile, shootDelay, ammo, shootSpeed, shootPos));
                break;
            case Constants.FAN_ATTACK:
                StartCoroutine(AttackFan.ShootInWaves(enemy, missile, shootDelay, ammo, shootSpeed, shootPos));
                break;
            case Constants.HOMING_ATTACK:
                StartCoroutine(AttackHoming.ShootInWaves(enemy, missile, shootDelay, ammo, shootSpeed, shootPos, player.transform));
                break;
            case Constants.CIRCLE_ATTACK:
                StartCoroutine(AttackCircle.ShootInWaves(enemy, missile, shootDelay, ammo, shootSpeed, shootPos));
                break;
            case Constants.SPIRAL_ATTACK:
                StartCoroutine(AttackSpiral.ShootInWaves(enemy, missile, shootDelay, ammo, shootSpeed, shootPos));
                break;
            case Constants.RANDOM_ATTACK:
                StartCoroutine(AttackRandom.ShootInWaves(enemy, missile, shootDelay, ammo, shootSpeed, shootPos));
                break;
            case Constants.VERTICAL_AND_HOMING_ATTACK:
                StartCoroutine(AttackVertical.ShootInWaves(enemy, missile, shootDelay, ammo, shootSpeed, shootPos));
                goto case Constants.HOMING_ATTACK;
            case Constants.FAN_AND_HOMING_ATTACK:
                StartCoroutine(AttackFan.ShootInWaves(enemy, missile, shootDelay, ammo, shootSpeed, shootPos));
                goto case Constants.HOMING_ATTACK;
            case Constants.CIRCLE_AND_HOMING_ATTACK:
                StartCoroutine(AttackCircle.ShootInWaves(enemy, missile, shootDelay, ammo, shootSpeed, shootPos));
                goto case Constants.HOMING_ATTACK;
            case Constants.SPIRAL_AND_HOMING_ATTACK:
                StartCoroutine(AttackSpiral.ShootInWaves(enemy, missile, shootDelay, ammo, shootSpeed, shootPos));
                goto case Constants.HOMING_ATTACK;
            case Constants.RANDOM_AND_HOMING_ATTACK:
                StartCoroutine(AttackRandom.ShootInWaves(enemy, missile, shootDelay, ammo, shootSpeed, shootPos));
                goto case Constants.HOMING_ATTACK;
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
        this.shootBehaviour = e.shootBehaviour;
        this.shootDelay = e.shootDelay;
        this.xPartition = e.xPartition;
        this.yPartition = e.yPartition;
    }

    public void EmptyAmmo()
    {
        this.ammo = 0;
    }
}
