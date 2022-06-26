using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class QuestionGenerator : MonoBehaviour
{
    public TMP_Text question;
    public int min, max;
    public int X, Y;

    // Start is called before the first frame update
    void Start()
    {
        question = GetComponent<TMP_Text>();
        min = 0;
        max = 10;
        X = Random.Range(min,max);
        Y = Random.Range(min,max);
        question.text = X + " + " + Y + " = ?";
    }

}
