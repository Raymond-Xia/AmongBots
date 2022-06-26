using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE: " + MissileMovement.score.ToString();
    }
}
