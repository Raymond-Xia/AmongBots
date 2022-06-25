using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTimer : MonoBehaviour
{
    GameObject boss;
    float delay = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("Boss");
        StartCoroutine(WaitAndShow(boss, delay));   
    }

    IEnumerator WaitAndShow(GameObject go, float delay)
    {
        boss.SetActive(false);
        yield return new WaitForSeconds(delay);
        boss.SetActive(true);
    }
}
