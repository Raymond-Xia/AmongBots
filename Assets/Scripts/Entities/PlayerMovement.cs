using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public static int hp = Constants.MAX_HP;
    public static bool invulnerable = false;
    public bool moveAllowed;
    public bool beingEjected;
    public Collider2D col;
    public Vector2 touchPosition;
    Collider2D touchedCollider;
    public Transform canvas;
    public Vector2 canvasPosition;
    public GameObject player;
    public GameObject skin;
    public GameObject deathBot;
    public AudioSource hitSound;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find(Constants.CANVAS_OBJECT).transform;
        canvasPosition = GameObject.Find(Constants.CANVAS_OBJECT).transform.position;
        player = GameObject.Find(Constants.PLAYER_OBJECT);
        skin = GameObject.Find(Constants.SKIN_OBJECT);
        col = GetComponent<Collider2D>();

        player.GetComponent<Image>().sprite = Cosmetics.UpdateSprite();
        skin.GetComponent<Image>().sprite = Cosmetics.UpdateSkin();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Time.timeScale > 0 && !beingEjected)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = touch.position;

            // when the finger first touches the screen
            if (touch.phase == TouchPhase.Began)
            {
                touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if (col == touchedCollider)
                {
                    moveAllowed = true;
                }
            }

            // if finger is still on screen and moving around
            if (touch.phase == TouchPhase.Moved)
            {
                if (moveAllowed)
                {
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);
                    skin.transform.position = new Vector2(touchPosition.x, touchPosition.y + 25);
                }
            }

            // if stopped touching screen
            if (touch.phase == TouchPhase.Ended)
            {
                moveAllowed = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!invulnerable && (collision.tag == Constants.ENEMY_TAG || collision.tag == Constants.MISSILE_TAG))
        {
            hp -= 1;
            if (hp == 0)
            {
                DeathAnimation();
                invulnerable = false;
            }
            hitSound.Play();
            StartCoroutine(IFrames());
        }

        if (collision.tag == Constants.HEALTHPOWERUP_TAG)
        {
            if (hp < Constants.MAX_HP)
            {
                hp += 1;
            }
        }

        if (collision.tag == Constants.NUKEPOWERUP_TAG)
        {
            NukeButton script = GameObject.Find(Constants.NUKEBUTTON_TAG).GetComponent<NukeButton>();
            script.activateButton();
        }
    }

    public void DeathAnimation() 
    {
        beingEjected = true;
        GameObject newDeathBot = Instantiate(deathBot, new Vector2(0, player.transform.position.y), Quaternion.identity, canvas) as GameObject;
        newDeathBot.transform.SetSiblingIndex(1);
        newDeathBot.GetComponent<Rigidbody2D>().velocity = new Vector2(30000f * Time.fixedDeltaTime,0);    
    } 

    void LoadLoseScene() 
    {
        SceneManager.LoadScene(Constants.LOSE_SCENE);
    }
    
    private IEnumerator IFrames()
    {
        float time = 1;
        invulnerable = true;
        while (time >= 0.005f)
        {
            time -= Time.deltaTime;
            if ((int)(time * 10) % 2 == 0)
            {
                var playerColor = player.GetComponent<Image>().color;
                playerColor.a = 1f;
                player.GetComponent<Image>().color = playerColor;
                var skinColor = skin.GetComponent<Image>().color;
                skinColor.a = 1f;
                player.GetComponent<Image>().color = skinColor;
            }
            else
            {
                var playerColor = player.GetComponent<Image>().color;
                playerColor.a = 0.5f;
                player.GetComponent<Image>().color = playerColor;
                var skinColor = skin.GetComponent<Image>().color;
                skinColor.a = 0.5f;
                player.GetComponent<Image>().color = skinColor;
            }

            yield return null;
        }
        if (time < 0.005f)
        {
            invulnerable = false;
            var playerColor = player.GetComponent<Image>().color;
            playerColor.a = 1f;
            player.GetComponent<Image>().color = playerColor;
            var skinColor = skin.GetComponent<Image>().color;
            skinColor.a = 1f;
            player.GetComponent<Image>().color = skinColor;
        }
    }
}
