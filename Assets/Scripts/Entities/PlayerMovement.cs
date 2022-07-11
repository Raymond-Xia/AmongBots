using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public static int hp = 5;
    public static string[] sprites = new string[]
    {
        Constants.BLACK_CREWMATE,
        Constants.BLUE_CREWMATE,
        Constants.BROWN_CREWMATE,
        Constants.CYAN_CREWMATE,
        Constants.GREEN_CREWMATE,
        Constants.LIME_CREWMATE,
        Constants.ORANGE_CREWMATE,
        Constants.PINK_CREWMATE,
        Constants.PURPLE_CREWMATE,
        Constants.RED_CREWMATE,
        Constants.WHITE_CREWMATE,
        Constants.YELLOW_CREWMATE
    };

    public bool moveAllowed;
    public Collider2D col;
    public Vector2 touchPosition;
    Collider2D touchedCollider;
    public Vector2 canvasPosition;

    // Start is called before the first frame update
    void Start()
    {
        canvasPosition = GameObject.Find(Constants.CANVAS_OBJECT).transform.position;
        col = GetComponent<Collider2D>();
        UpdateSprite();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
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
                // if (moveAllowed && touchPosition.y < canvasPosition.y - 100)
                if (moveAllowed)
                {
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);
                }
            }

            // if stopped touching screen
            if (touch.phase == TouchPhase.Ended)
            {
                moveAllowed = false;
            }
        }
    }

    private void UpdateSprite()
    {
        int selected = 3;
        if (PlayerPrefs.HasKey(Constants.SPRITE_SELECTED_KEY))
        {
            selected = PlayerPrefs.GetInt(Constants.SPRITE_SELECTED_KEY);
        }
        Sprite sprite = Resources.Load<Sprite>(sprites[selected]);
        GameObject.Find(Constants.PLAYER_OBJECT).GetComponent<Image>().sprite = sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Constants.ENEMY_TAG || collision.tag == Constants.MISSILE_TAG)
        {
            hp = hp - 1;
            if (hp == 0)
            {
                SceneManager.LoadScene(Constants.LOSE_SCENE);
                hp = 5;
            }
        }
    }
}
