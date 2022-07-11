using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject[] buttons = new GameObject[Constants.SPRITES.Length];

    public void UpdateInventory()
    {
        foreach (Transform child in GameObject.Find(Constants.SCROLL_CONTENT_INVENTORY).transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        GameObject.Find(Constants.SCROLL_VIEW_INVENTORY).GetComponent<ScrollRect>().verticalNormalizedPosition = 1;
        char[] owned = Constants.SPRITE_OWNED_MASK.ToCharArray();
        if (PlayerPrefs.HasKey(Constants.SPRITE_OWNED_KEY))
        {
            owned = PlayerPrefs.GetString(Constants.SPRITE_OWNED_KEY).ToCharArray();
        }
        Debug.Log(new string(owned));

        int h = 1600;
        for (int i = 0; i < owned.Length; i++)
        {
            if (owned[i].Equals('1'))
            {
                buttons[i] = new GameObject();
                buttons[i].transform.parent = GameObject.Find(Constants.SCROLL_CONTENT_INVENTORY).transform;
                int x = i;
                buttons[i].AddComponent<Button>().onClick.AddListener(delegate { selectCrewmate(x); });

                GameObject crewmate = new GameObject();
                Sprite sprite = Resources.Load<Sprite>(Constants.SPRITES[i]);
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
        PlayerPrefs.SetInt(Constants.SPRITE_SELECTED_KEY, i);
        PlayerPrefs.Save();
    }
}
