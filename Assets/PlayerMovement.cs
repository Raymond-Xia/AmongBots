using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public bool moveAllowed;
    public Collider2D col;
    public Vector2 touchPosition;
    Collider2D touchedCollider;
    public Vector2 canvasPosition;
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
}
