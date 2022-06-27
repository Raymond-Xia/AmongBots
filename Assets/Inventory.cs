using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public string[] skins = new string[]
    {
        "Sprites/CrewmateBlack",
        "Sprites/CrewmateBlue",
        "Sprites/CrewmateBrown",
        "Sprites/CrewmateCyan",
        "Sprites/CrewmateGreen",
        "Sprites/CrewmateLime",
        "Sprites/CrewmateOrange",
        "Sprites/CrewmatePink",
        "Sprites/CrewmatePurple",
        "Sprites/CrewmateRed",
        "Sprites/CrewmateWhite",
        "Sprites/CrewmateYellow"
    };

    public GameObject[] buttons = new GameObject[12];

    public void UpdateInventory()
    {
        // This renders the inventory on top of the old one :^)
        GameObject.Find("ScrollView").GetComponent<ScrollRect>().verticalNormalizedPosition = 1;
        char[] owned = "000000000000".ToCharArray();
        if (PlayerPrefs.HasKey("owned"))
        {
            owned = PlayerPrefs.GetString("owned").ToCharArray();
        }

        int h = 1600;
        for (int i = 0; i < owned.Length; i++)
        {
            if (owned[i].Equals('1'))
            {
                buttons[i] = new GameObject();
                buttons[i].transform.parent = GameObject.Find("ScrollContent").transform;
                int x = i;
                buttons[i].AddComponent<Button>().onClick.AddListener(delegate { selectCrewmate(x); });

                GameObject crewmate = new GameObject();
                Sprite sprite = Resources.Load<Sprite>(skins[i]);
                crewmate.AddComponent<Image>().sprite = sprite;
                RectTransform crewmateRectTransform = crewmate.GetComponent<RectTransform>();
                crewmateRectTransform.SetParent(buttons[i].transform, true);
                crewmateRectTransform.transform.localScale = new Vector2(3.45f, 3);
                crewmateRectTransform.transform.position = new Vector2(Screen.width / 2, h);
                crewmate.SetActive(true);
                h -= 500;
            }
        }
    }

    void selectCrewmate(int i)
    {
        PlayerPrefs.SetInt("selected", i);
        PlayerPrefs.Save();
    }
}
