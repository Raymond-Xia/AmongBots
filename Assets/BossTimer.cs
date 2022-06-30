using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTimer : MonoBehaviour
{
    public GameObject boss;
    float delay = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndShow(boss, delay));   
    }

    IEnumerator WaitAndShow(GameObject go, float delay)
    {
        yield return new WaitForSeconds(delay);
        Transform canvas = GameObject.Find("Canvas").transform;
        GameObject newBoss = Instantiate(boss, new Vector2(canvas.position.x, canvas.position.y + 1600), Quaternion.identity, canvas) as GameObject;
    }
}
