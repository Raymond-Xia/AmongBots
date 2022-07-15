using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CueCardMenu : MonoBehaviour
{
    public GameObject[] cards = new GameObject[100];
    public Font font;
    public static Dictionary<string, string> cardmap = new Dictionary<string, string>();
    public float h;
    public float thing;
    public GameObject cueCardPrefab;

    // Start is called before the first frame update
    void Start()
    {
        cardmap.Add("What is the largest planet in our solar system?", "Jupiter");
        cardmap.Add("What is swag?", "yo mama");
        UpdateCueCards();
    }

    public void UpdateCueCards()
    {
        foreach (Transform child in GameObject.Find("CardScrollContent").transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        GameObject.Find("CardScrollView").GetComponent<ScrollRect>().verticalNormalizedPosition = 1;
        // char[] owned = Constants.SPRITE_OWNED_MASK.ToCharArray();
        // if (PlayerPrefs.HasKey(Constants.SPRITE_OWNED_KEY))
        // {
        //     owned = PlayerPrefs.GetString(Constants.SPRITE_OWNED_KEY).ToCharArray();
        // }
        // Debug.Log(new string(owned));
        h = 1350;
        bool first = true;
        foreach (KeyValuePair<string, string> pair in cardmap)
        {
            
            // if (cards[i].Equals('1'))
            // {
            // GameObject card = new GameObject();
            // card.transform.parent = GameObject.Find("CardScrollContent").transform;
            // int x = i;
            // cards[i].AddComponent<Button>().onClick.AddListener(delegate { selectCrewmate(x); });

            // GameObject crewmate = new GameObject();
            // Sprite sprite = Resources.Load<Sprite>(Constants.SPRITES[i]);
            // crewmate.AddComponent<Image>().sprite = sprite;
            // RectTransform crewmateRectTransform = crewmate.GetComponent<RectTransform>();
            // crewmateRectTransform.SetParent(cards[i].transform, true);
            // crewmateRectTransform.transform.localScale = new Vector2(3.45f, 3);
            // crewmateRectTransform.transform.position = new Vector2(Screen.width / 2, h);
            // crewmate.SetActive(true);
            // h -= 500;
            GameObject newCard = Instantiate(cueCardPrefab, new Vector2(0,0), Quaternion.identity, GameObject.Find("CardScrollContent").transform) as GameObject;

            Text text = newCard.transform.GetChild(0).GetComponent<Text>();
            text.text = "Q: " + pair.Key + "\nA: " + pair.Value;
            // RectTransform cardRectTransform = cardtext.GetComponent<RectTransform>();
            // cardRectTransform.SetParent(cardtext.transform, false);
            if (!first) h -= text.preferredHeight/2; else first = false;
            newCard.transform.position = new Vector2(Screen.width / 2, h);

            // ContentSizeFitter fit;
            // fit.verticalFit = PreferredSize;

            // cardRectTransform.sizeDelta = new Vector2(290, text.fontSize+100);
            // cardtext.SetActive(true);
            thing = text.preferredHeight;
            // h -= ((RectTransform)newCard.transform).rect.height;
            h -= text.preferredHeight/2 + 50;
            // }
        }
    }

    public void CreateCueCard() 
    {
        string question = GameObject.Find("QuestionInput").GetComponent<InputField>().text;
        string answer = GameObject.Find("AnswerInput").GetComponent<InputField>().text;
        Debug.Log(question);
        Debug.Log(answer);
        Debug.Log(cardmap.Count);
        if (!cardmap.ContainsKey(question)) {
            cardmap.Add(question, answer);
        } else {
            cardmap[question] = answer;
        }

        Debug.Log(cardmap.Count);
        GameObject.Find("QuestionInput").GetComponent<InputField>().text = "";
        GameObject.Find("AnswerInput").GetComponent<InputField>().text = "";
    }

    // void SaveCueCards(int i)
    // {
    //     PlayerPrefs.SetInt(Constants.SPRITE_SELECTED_KEY, i);
    //     PlayerPrefs.Save();
    // }
}
