using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public static int hp = 5;

    public bool moveAllowed;
    public Collider2D col;
    public Vector2 touchPosition;
    Collider2D touchedCollider;
    public Vector2 canvasPosition;
    public GameObject player;
    public GameObject skin;    

    // Start is called before the first frame update
    void Start()
    {
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
        if (Input.touchCount > 0 && Time.timeScale > 0)
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
                    skin.transform.position = new Vector2(touchPosition.x, touchPosition.y);
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
        if (collision.tag == Constants.ENEMY_TAG || collision.tag == Constants.MISSILE_TAG)
        {
            hp -= 1;
            if (hp == 0)
            {
                SceneManager.LoadScene(Constants.LOSE_SCENE);
                hp = 5;
            }
        }

        if (collision.tag == Constants.HEALTHPOWERUP_TAG)
        {
            hp += 1;
        }

        if (collision.tag == Constants.NUKEPOWERUP_TAG)
        {
            NukeButton script = GameObject.Find("NukeButton").GetComponent<NukeButton>();
            script.activateButton();
        }
    }
}
