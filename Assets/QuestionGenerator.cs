using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class QuestionGenerator : MonoBehaviour
{
    public TMP_Text question;
    public TMP_Text a1;
    public TMP_Text a2;
    public TMP_Text a3;
    public int minNum, maxNum;
    public int X, Y;

    // Start is called before the first frame update
    void Start()
    {
        question = GetComponent<TMP_Text>();
        a1 = GameObject.Find("A1Text").GetComponent<TMP_Text>();
        minNum = 0;
        maxNum = 10;
        X = Random.Range(minNum,maxNum);
        Y = Random.Range(minNum,maxNum);
        int answer = X + Y;
        question.text = X + " + " + Y + " = ?";
        a1.text = answer + "";
    }

}
