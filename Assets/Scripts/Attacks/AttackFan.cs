using System.Collections;
using UnityEngine;

public class AttackFan : MonoBehaviour
{
    public float damage;

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

    public static IEnumerator Shoot(GameObject enemy, GameObject missile, float delay, int ammo, float shootSpeed, Transform shootPos)
    {
        while (ammo > 0)
        {
            int angle = 0;
            while (angle <= 180)
            {
                GameObject newMissile = Instantiate(missile, shootPos.position, Quaternion.identity) as GameObject;
                newMissile.GetComponent<Rigidbody2D>().velocity = new Vector2(-shootSpeed * Time.fixedDeltaTime * Mathf.Cos((angle * Mathf.PI) / 180), -shootSpeed * Time.fixedDeltaTime * Mathf.Sin((angle * Mathf.PI) / 180));
                newMissile.transform.SetParent(GameObject.Find(Constants.CANVAS_OBJECT).transform, true);
                angle += 45;
            }
            angle = 0;

            ammo -= 1;
            yield return new WaitForSeconds(delay);
        }
        enemy.SendMessage("EmptyAmmo", 0);
    }
}
