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
        StartCoroutine(MissileTimer(missile, 5.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        Debug.Log(collision.tag);
        if (collision.tag == "Player") 
        {
            Destroy(gameObject);
        }
    }

    IEnumerator MissileTimer(GameObject go, float delay) 
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
        score = score + 1;
    }
}
