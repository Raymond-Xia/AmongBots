using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    
    public bool moveAllowed;
    public Collider2D col;
    public Bounds colBounds;
    public Vector2 touchPosition;
    public Collider2D touchedCollider;
    public Vector2 canvasPosition;
    public int hp;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) 
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = touch.position;

            colBounds = col.bounds;

            canvasPosition = GameObject.Find("Canvas").transform.position;

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
                }
            }

            // if stopped touching screen
            if (touch.phase == TouchPhase.Ended) 
            {
                moveAllowed = false;
            }
        }
    }

    public int getHealth() 
    {
        return hp;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        Debug.Log("asd");
        Debug.Log(collision.tag);
        if (collision.tag == "Enemy" || collision.tag == "Missile") 
        {
            hp = hp - 1;
            if (hp == 0) 
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
