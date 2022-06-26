using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionTimer : MonoBehaviour
{
    GameObject question;
    GameObject a1, a2, a3;
    float delay = 12.0f;

    // Start is called before the first frame update
    void Start()
    {
        question = GameObject.Find("Question");
        a1 = GameObject.Find("Answer1");
        a2 = GameObject.Find("Answer2");
        a3 = GameObject.Find("Answer3");
        question.SetActive(false);
        a1.SetActive(false);
        a2.SetActive(false);
        a3.SetActive(false);
        StartCoroutine(WaitAndShow(question, delay));   
    }

    IEnumerator WaitAndShow(GameObject go, float delay)
    {
        yield return new WaitForSeconds(delay);
        question.SetActive(true);        
        a1.SetActive(true);
        a2.SetActive(true);
        a3.SetActive(true);
    }
}
