using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackVertical : MonoBehaviour
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

    public static IEnumerator Shoot(GameObject missile, float delay, int ammo, float shootSpeed, Transform shootPos)
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
