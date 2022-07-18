using System.Collections;
using UnityEngine;

public class AttackCircle : Attack
{
    public static void ShootOnDemand(GameObject enemy, GameObject missile, float shootSpeed, Transform shootPos, int angleOffset) 
    {
        int angle = angleOffset;
        while (angle <= 330 + angleOffset)
        {
            GameObject newMissile = Instantiate(missile, shootPos.position, Quaternion.identity) as GameObject;
            newMissile.GetComponent<Rigidbody2D>().velocity = new Vector2(-shootSpeed * Time.fixedDeltaTime * Mathf.Cos((angle * Mathf.PI) / 180), -shootSpeed * Time.fixedDeltaTime * Mathf.Sin((angle * Mathf.PI) / 180));
            newMissile.transform.SetParent(GameObject.Find(Constants.CANVAS_OBJECT).transform, true);
            newMissile.transform.SetSiblingIndex(4);
            angle += 30;
        }
        angle = angleOffset;
    }

    public static IEnumerator ShootInWaves(GameObject enemy, GameObject missile, float delay, int ammo, float shootSpeed, Transform shootPos)
    {
        int angleOffset = 0;
        while (ammo > 0)
        {
            ShootOnDemand(enemy, missile, shootSpeed, shootPos, angleOffset % 30);
            ammo -= 1;
            yield return new WaitForSeconds(delay);
            angleOffset += 10;
        }
        enemy.SendMessage("EmptyAmmo", 0);
    }
}
