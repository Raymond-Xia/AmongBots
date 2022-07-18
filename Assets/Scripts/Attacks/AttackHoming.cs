using System.Collections;
using UnityEngine;

public class AttackHoming : Attack
{
    public static void ShootOnDemand(GameObject enemy, GameObject missile, float shootSpeed, Transform shootPos, Transform playerPos) 
    {
        GameObject newMissile = Instantiate(missile, shootPos.position, Quaternion.identity) as GameObject;

            EnemyAI.laserSound.Play();
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
        newMissile.transform.SetSiblingIndex(4);
        EnemyAI.laserSound.Play();
    }

    public static IEnumerator ShootInWaves(GameObject enemy, GameObject missile, float delay, int ammo, float shootSpeed, Transform shootPos, Transform playerPos)
    {
        while (ammo > 0)
        {
            ShootOnDemand(enemy, missile, shootSpeed, shootPos, playerPos);
            ammo -= 1;
            yield return new WaitForSeconds(delay);
        }
        enemy.SendMessage(Constants.EMPTY_AMMO, 0);
    }
}
