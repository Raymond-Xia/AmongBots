using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CueCardQuestionGenerator : MonoBehaviour
{
    public Text questionObject;
    public string question;
    public string answer;
    // external use only
    public static string latestQuestion;

    // Start is called before the first frame update
    void Start()
    {
        // Pick random cue card question
        List<KeyValuePair<string, string>> cardList = CueCardMenu.cardmap.ToList();       
        if (LevelController.usedCueCards.Count < cardList.Count) {
            foreach (KeyValuePair<string, string> card in LevelController.usedCueCards) {
                cardList.Remove(card);
            }     
        } else {
            LevelController.usedCueCards.Clear();
        }
        KeyValuePair<string, string> randomCard = cardList[Random.Range(0, cardList.Count)];
        question = randomCard.Key;
        questionObject.text = question;
        latestQuestion = question;
        answer = randomCard.Value;
        LevelController.usedCueCards.Add(randomCard);
    }
}
