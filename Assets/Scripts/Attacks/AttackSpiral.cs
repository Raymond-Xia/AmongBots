using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpiral : Attack
{
    public static IEnumerator ShootInWaves(GameObject enemy, GameObject missile, float delay, int ammo, float shootSpeed, Transform shootPos)
    {
        while (ammo > 0)
        {
            int angle = 0;
            while (angle <= 345)
            {
                GameObject newMissile = Instantiate(missile, shootPos.position, Quaternion.identity) as GameObject;
                newMissile.GetComponent<Rigidbody2D>().velocity = new Vector2(-shootSpeed * Time.fixedDeltaTime * Mathf.Cos((angle * Mathf.PI) / 180), -shootSpeed * Time.fixedDeltaTime * Mathf.Sin((angle * Mathf.PI) / 180));
                newMissile.transform.SetParent(GameObject.Find(Constants.CANVAS_OBJECT).transform, true);
                newMissile.transform.SetSiblingIndex(4);
                angle += 15;
                EnemyAI.laserSound.Play();
                yield return new WaitForSeconds(0.01f);
            }
            angle = 0;
            
            ammo -= 1;
            yield return new WaitForSeconds(delay);
        }
        enemy.SendMessage("EmptyAmmo", 0);
    }
}
