using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTimer : MonoBehaviour
{
    GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("Boss");
        StartCoroutine(ShowAndHide(boss, 10.0f));   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ShowAndHide(GameObject go, float delay)
    {
        boss.SetActive(false);
        yield return new WaitForSeconds(delay);
        boss.SetActive(true);
    }
}
