using System.Collections;
using UnityEngine;

public class DeathBotAI : MonoBehaviour
{
    public Transform canvas;
    public GameObject player;
    public GameObject skin;
    public GameObject deathBot;
    public Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find(Constants.PLAYER_OBJECT);
        skin = GameObject.Find(Constants.SKIN_OBJECT);
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        skin.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 25);
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == Constants.PLAYER_TAG) 
        {
            body.velocity = new Vector2(0, 0);
            yield return new WaitForSeconds(0.75f);
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(30000f * Time.fixedDeltaTime, 0);
            yield return new WaitUntil(new System.Func<bool>(() => player.transform.position.x > Screen.width));
            player.SendMessage("LoadLoseScene", 0);
        }
    }
}
