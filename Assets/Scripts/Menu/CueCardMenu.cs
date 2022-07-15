using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class CueCardMenu : MonoBehaviour
{
    public GameObject[] cards = new GameObject[100];
    public static Dictionary<string, string> cardmap = new Dictionary<string, string>();
    public GameObject cueCardPrefab;

    // Start is called before the first frame update
    void Start()
    {
        UpdateCueCards();
    }

    public void UpdateCueCards()
    {
        // Load saved cue cards data
        if(File.Exists(Application.persistentDataPath + "/savedCueCards.gd")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedCueCards.gd", FileMode.Open);
            Debug.Log(cardmap);
            cardmap = (Dictionary<string, string>)bf.Deserialize(file);
            Debug.Log(cardmap);
            file.Close();
        } else {
            Debug.Log("Save file does not exist.");
        }

        // Clear screen
        foreach (Transform child in GameObject.Find("CardScrollContent").transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        GameObject.Find("CardScrollView").GetComponent<ScrollRect>().verticalNormalizedPosition = 1;

        // Display cue cards
        float h = 1350;
        bool first = true;
        foreach (KeyValuePair<string, string> pair in cardmap)
        {
            GameObject newCard = Instantiate(cueCardPrefab, new Vector2(0,0), Quaternion.identity, GameObject.Find("CardScrollContent").transform) as GameObject;

            Text text = newCard.transform.GetChild(0).GetComponent<Text>();
            text.text = "Q: " + pair.Key + "\nA: " + pair.Value;
            // RectTransform cardRectTransform = cardtext.GetComponent<RectTransform>();
            // cardRectTransform.SetParent(cardtext.transform, false);
            if (!first) h -= text.preferredHeight/2; else first = false;
            newCard.transform.position = new Vector2(Screen.width / 2, h);
            
            h -= text.preferredHeight/2 + 50;
        }
    }

    public void CreateCueCard() 
    {
        string question = GameObject.Find("QuestionInput").GetComponent<InputField>().text;
        string answer = GameObject.Find("AnswerInput").GetComponent<InputField>().text;
        if (!cardmap.ContainsKey(question)) {
            cardmap.Add(question, answer);
        } else {
            cardmap[question] = answer;
        }

        Debug.Log(cardmap.Count);
        GameObject.Find("QuestionInput").GetComponent<InputField>().text = "";
        GameObject.Find("AnswerInput").GetComponent<InputField>().text = "";
        SaveCueCards();
    }

    public static void SaveCueCards() 
    {
        Debug.Log(Application.persistentDataPath);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create (Application.persistentDataPath + "/savedCueCards.gd");
        bf.Serialize(file, cardmap);
        file.Close();
    }
}
