using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeleteCueCards : MonoBehaviour
{
    public void DeleteCueCard() 
    {
        string s = transform.parent.GetChild(0).GetComponent<Text>().text;
        string key = s.Substring(3, s.IndexOf("\nA: ") - 3); // scuffed question parsing
        CueCardMenu.cardmap.Remove(key);
        CueCardMenu.SaveCueCards();

        CueCardMenu script = GameObject.Find(Constants.CARDS_SCREEN).GetComponent<CueCardMenu>();
        script.UpdateCueCards();
    }

    public void DeleteAllCueCards() 
    {
        CueCardMenu.cardmap.Clear();
        CueCardMenu.SaveCueCards();

        CueCardMenu script = transform.parent.GetChild(transform.GetSiblingIndex()-2).GetComponent<CueCardMenu>();
        script.UpdateCueCards();
    }
}
