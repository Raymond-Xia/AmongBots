using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CueCardQuestionGenerator : MonoBehaviour
{
    public Text questionObject;
    public string question;
    public string answer;

    // Start is called before the first frame update
    void Start()
    {
        // Pick random cue card question
        KeyValuePair<string, string> randomCard = CueCardMenu.cardmap.ToList()[Random.Range(0, CueCardMenu.cardmap.Count)];
        question = randomCard.Key;
        questionObject.text = question;
        answer = randomCard.Value;
    }
}
