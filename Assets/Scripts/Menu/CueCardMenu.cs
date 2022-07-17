using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using TMPro;

public class CueCardMenu : MonoBehaviour
{
    public static Dictionary<string, string> cardmap = new Dictionary<string, string>();
    public GameObject cueCardPrefab;
    public Transform cardScrollContent;
    public Transform cardScrollView;
    public TMP_InputField questionInput;
    public TMP_InputField answerInput;
    public Text createCardPrompt;

    public void UpdateCueCards()
    {
        // Load saved cue cards data
        if(File.Exists(Application.persistentDataPath + Constants.CARD_SAVE_FILE)) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + Constants.CARD_SAVE_FILE, FileMode.Open);
            cardmap = (Dictionary<string, string>)bf.Deserialize(file);
            file.Close();
        } 

        // Clear screen
        foreach (Transform child in cardScrollContent)
        {
            GameObject.Destroy(child.gameObject);
        }

        // Display cue cards
        foreach (KeyValuePair<string, string> pair in cardmap)
        {
            GameObject newCard = Instantiate(cueCardPrefab, new Vector2(0,0), Quaternion.identity, cardScrollContent) as GameObject;
            cardScrollView.GetComponent<ScrollRect>().verticalNormalizedPosition = 1;

            Text text = newCard.transform.GetChild(0).GetComponent<Text>();
            text.text = string.Format(Constants.CARD_TEXT_FORMAT, pair.Key, pair.Value);
        }
    }

    public void CreateCueCard() 
    {
        if (cardmap.Count >= Constants.MAX_CUE_CARDS) { // can't add more than max cards (100)
            createCardPrompt.text = string.Format(Constants.MAX_CARDS_MSG, Constants.MAX_CUE_CARDS);
        } else { 
            if (questionInput.text == "" || answerInput.text == "" || questionInput.text == "\n" || answerInput.text == "\n") { // empty fields check
                createCardPrompt.text = Constants.EMPTY_FIELDS_MSG;
            } else {
                RemoveWhiteSpace();
                if (!cardmap.ContainsKey(questionInput.text)) { // add card
                    cardmap.Add(questionInput.text, answerInput.text);
                    createCardPrompt.text = Constants.CARD_ADDED_MSG;
                } else { // overwrite card
                    cardmap[questionInput.text] = answerInput.text;
                    createCardPrompt.text = Constants.CARD_OVERWRITTEN_MSG; 
                }

                questionInput.text = "";
                answerInput.text = "";
                SaveCueCards();
            }
        } 
    }

    public static void SaveCueCards() 
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create (Application.persistentDataPath + Constants.CARD_SAVE_FILE);
        bf.Serialize(file, cardmap);
        file.Close();
    }

    public void RemoveWhiteSpace()
    {
        if (questionInput.text.Contains("\n")) {
            questionInput.text = questionInput.text.Replace("\n", "");
        }
        if (answerInput.text.Contains("\n")) {
            answerInput.text = answerInput.text.Replace("\n", "");
        }
        questionInput.text = questionInput.text.Trim();
        answerInput.text = answerInput.text.Trim();
    }
    
}
