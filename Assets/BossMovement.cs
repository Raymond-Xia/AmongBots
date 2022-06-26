using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public Vector2 targetPosition;
    public float speed; 

    // Start is called before the first frame update
    void Start()
    {
        Vector2 canvasPosition = GameObject.Find("Canvas").transform.position;
        targetPosition = new Vector2(canvasPosition.x, canvasPosition.y + 400);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector2)transform.position != targetPosition) 
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        } 
    }
    
}
