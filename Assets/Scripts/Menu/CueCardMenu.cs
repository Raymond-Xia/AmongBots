using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class CueCardMenu : MonoBehaviour
{
    public static Dictionary<string, string> cardmap = new Dictionary<string, string>();
    public GameObject cueCardPrefab;

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
        Transform cardScrollContent = GameObject.Find(Constants.CARD_SCROLL_CONTENT).transform;
        foreach (Transform child in cardScrollContent)
        {
            GameObject.Destroy(child.gameObject);
        }

        // Display cue cards
        foreach (KeyValuePair<string, string> pair in cardmap)
        {
            GameObject newCard = Instantiate(cueCardPrefab, new Vector2(0,0), Quaternion.identity, cardScrollContent) as GameObject;
            GameObject.Find(Constants.CARD_SCROLL_VIEW).GetComponent<ScrollRect>().verticalNormalizedPosition = 1;

            Text text = newCard.transform.GetChild(0).GetComponent<Text>();
            text.text = string.Format(Constants.CARD_TEXT_FORMAT, pair.Key, pair.Value);
        }
    }

    public void CreateCueCard() 
    {
        Text prompt = GameObject.Find(Constants.CARD_ADD_PROMPT).GetComponent<Text>();
        if (cardmap.Count >= Constants.MAX_CUE_CARDS) { // can't add more than max cards (100)
            prompt.text = string.Format(Constants.MAX_CARDS_MSG, Constants.MAX_CUE_CARDS);
        } else { 
            InputField question = GameObject.Find(Constants.CARD_QUESTION_INPUT).GetComponent<InputField>();
            InputField answer = GameObject.Find(Constants.CARD_ANSWER_INPUT).GetComponent<InputField>();
            if (question.text == "" || answer.text == "") { // empty fields check
                prompt.text = Constants.EMPTY_FIELDS_MSG;
            } else { // add or overwrite card
                if (!cardmap.ContainsKey(question.text)) {
                    cardmap.Add(question.text, answer.text);
                } else {
                    cardmap[question.text] = answer.text;
                }

                question.text = "";
                answer.text = "";
                prompt.text = Constants.CARD_ADDED_MSG;
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
}
