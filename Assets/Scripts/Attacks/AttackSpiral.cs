using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpiral : Attack
{
    public static IEnumerator ShootInWaves(GameObject enemy, GameObject missile, float delay, int ammo, float shootSpeed, Transform shootPos)
    {
        while (ammo > 0)
        {
            
            System.Random r = new System.Random();
            int angleOffset = r.Next(0, 4);
            angleOffset = (angleOffset * 5) % 20;
            int angle = angleOffset;
            while (angle <= 340 + angleOffset)
            {
                GameObject newMissile = Instantiate(missile, shootPos.position, Quaternion.identity) as GameObject;
                newMissile.GetComponent<Rigidbody2D>().velocity = new Vector2(-shootSpeed * Time.fixedDeltaTime * Mathf.Cos((angle * Mathf.PI) / 180), -shootSpeed * Time.fixedDeltaTime * Mathf.Sin((angle * Mathf.PI) / 180));
                newMissile.transform.SetParent(GameObject.Find(Constants.CANVAS_OBJECT).transform, true);
                newMissile.transform.SetSiblingIndex(4);
                angle += 20;
                EnemyAI.laserSound.Play();
                yield return new WaitForSeconds(0.01f);
            }
            angle = angleOffset;
            
            ammo -= 1;
            yield return new WaitForSeconds(delay);
        }
        enemy.SendMessage(Constants.EMPTY_AMMO, 0);
    }
}
