using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public void UpdateInventory()
    {
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
                Sprite sprite = Resources.Load<Sprite>(skins[i]);
                GameObject gameObj = new GameObject();
                Image newImg = gameObj.AddComponent<Image>();
                newImg.sprite = sprite;
                gameObj.GetComponent<RectTransform>().SetParent(GameObject.Find("ScrollContent").transform, true);
                gameObj.GetComponent<RectTransform>().transform.localScale = new Vector2(3.45f, 3);
                gameObj.GetComponent<RectTransform>().transform.position = new Vector2(Screen.width / 2, h);
                h -= 500;
                gameObj.SetActive(true);
            }
        }
    }
}
