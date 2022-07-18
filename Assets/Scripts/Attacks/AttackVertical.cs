using System.Collections;
using UnityEngine;

public class AttackVertical : Attack
{
    public static void ShootOnDemand(GameObject enemy, GameObject missile, float shootSpeed, Transform shootPos) 
    {
        GameObject newMissile = Instantiate(missile, shootPos.position, Quaternion.identity) as GameObject;
        newMissile.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -shootSpeed * Time.fixedDeltaTime);
        newMissile.transform.SetParent(GameObject.Find(Constants.CANVAS_OBJECT).transform, true);
        newMissile.transform.SetSiblingIndex(4);
    }

    public static IEnumerator ShootInWaves(GameObject enemy, GameObject missile, float delay, int ammo, float shootSpeed, Transform shootPos)
    {
        while (ammo > 0)
        {
            ShootOnDemand(enemy, missile, shootSpeed, shootPos);
            ammo -= 1;
            yield return new WaitForSeconds(delay);
        }
        enemy.SendMessage("EmptyAmmo", 0);
    }
}
