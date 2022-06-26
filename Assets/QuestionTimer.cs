using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionTimer : MonoBehaviour
{
    GameObject question;
    float delay = 12.0f;

    // Start is called before the first frame update
    void Start()
    {
        question = GameObject.Find("Question");
        StartCoroutine(WaitAndShow(question, delay));   
    }

    IEnumerator WaitAndShow(GameObject go, float delay)
    {
        question.SetActive(false);
        yield return new WaitForSeconds(delay);
        question.SetActive(true);
    }
}
