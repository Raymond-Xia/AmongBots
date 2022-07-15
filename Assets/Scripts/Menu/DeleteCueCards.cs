using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeleteCueCards : MonoBehaviour
{
    public void DeleteCueCard() 
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(name);
        string s = transform.parent.GetChild(0).GetComponent<Text>().text;
        string key = s.Substring(3, s.IndexOf("\nA: ") - 3);
        Debug.Log(key);
        CueCardMenu.cardmap.Remove(key);
        CueCardMenu.SaveCueCards();

        CueCardMenu script = GameObject.Find("CueCards").GetComponent<CueCardMenu>();
        script.UpdateCueCards();
    }
}
