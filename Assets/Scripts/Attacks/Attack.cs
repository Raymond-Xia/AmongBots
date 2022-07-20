using UnityEngine;

public class Attack : MonoBehaviour
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
        if (!PlayerMovement.invulnerable && collision.tag == Constants.PLAYER_TAG)
        {
            Destroy(gameObject);
        }
    }
}
