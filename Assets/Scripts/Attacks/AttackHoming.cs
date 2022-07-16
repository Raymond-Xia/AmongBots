using System.Collections;
using UnityEngine;

public class AttackHoming : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0f || transform.position.y > Screen.height || transform.position.x > Screen.width || transform.position.x < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Constants.PLAYER_TAG)
        {
            Destroy(gameObject);
        }
    }

    public static void ShootOnDemand(GameObject enemy, GameObject missile, float shootSpeed, Transform shootPos, Transform playerPos) 
    {
        GameObject newMissile = Instantiate(missile, shootPos.position, Quaternion.identity) as GameObject;

        float x  = playerPos.position.x - shootPos.position.x;
        float y = playerPos.position.y - shootPos.position.y;
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

        newMissile.GetComponent<Rigidbody2D>().velocity = new Vector2(x * shootSpeed * Time.fixedDeltaTime, y * shootSpeed * Time.fixedDeltaTime);
        newMissile.transform.SetParent(GameObject.Find(Constants.CANVAS_OBJECT).transform, true);
    }

    public static IEnumerator ShootInWaves(GameObject enemy, GameObject missile, float delay, int ammo, float shootSpeed, Transform shootPos, Transform playerPos)
    {
        while (ammo > 0)
        {
            ShootOnDemand(enemy, missile, shootSpeed, shootPos, playerPos);
            ammo -= 1;
            yield return new WaitForSeconds(delay);
        }
        enemy.SendMessage("EmptyAmmo", 0);
    }
}
