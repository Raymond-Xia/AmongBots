using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public bool moveAllowed;
    public Collider2D col;
    public Vector2 touchPosition;
    Collider2D touchedCollider;
    public Vector2 canvasPosition;
    public static int hp = 5;
    public static string[] sprites = new string[]
    {
        "Sprites/CrewmateBlack",
        "Sprites/CrewmateBlue",
        "Sprites/CrewmateBrown",
        "Sprites/CrewmateCyan",
        "Sprites/CrewmateGreen",
        "Sprites/CrewmateLime",
        "Sprites/CrewmateOrange",
        "Sprites/CrewmatePink",
        "Sprites/CrewmatePurple",
        "Sprites/CrewmateRed",
        "Sprites/CrewmateWhite",
        "Sprites/CrewmateYellow"
    };

    // Start is called before the first frame update
    void Start()
    {
        canvasPosition = GameObject.Find("Canvas").transform.position;
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
                if (moveAllowed && touchPosition.y < canvasPosition.y - 100)
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
        if (PlayerPrefs.HasKey("selected"))
        {
            selected = PlayerPrefs.GetInt("selected");
        }
        Sprite sprite = Resources.Load<Sprite>(sprites[selected]);
        GameObject.Find("Player").GetComponent<Image>().sprite = sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "Missile")
        {
            hp = hp - 1;
            if (hp == 0)
            {
                SceneManager.LoadScene(2);
                hp = 5;
            }
        }
    }
}
