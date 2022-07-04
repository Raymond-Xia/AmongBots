using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{
    public float damage;
    public GameObject missile;
    public static int score = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0f || transform.position.x > Screen.width || transform.position.x < 0) 
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player") 
        {
            Destroy(gameObject);
        }
    }
}
