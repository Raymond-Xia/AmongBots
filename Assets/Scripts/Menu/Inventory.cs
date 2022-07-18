using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public GameObject[] buttons = new GameObject[Constants.SPRITES.Length];

    public void UpdateInventory()
    {
        GameObject.Find(Constants.SCROLL_VIEW_INVENTORY).GetComponent<ScrollRect>().verticalNormalizedPosition = 1;
        int highScore = 0;
        if (PlayerPrefs.HasKey(Constants.SCORES_TOPSCORES))
        {
            highScore = int.Parse(PlayerPrefs.GetString(Constants.SCORES_TOPSCORES).Split("/n")[0]);
        }

        for (int i = 0; i < Constants.CREWMATES_INVENTORY.Length; i++)
        {
            if (highScore >= Constants.HIGHSCORE_THRESHOLDS[i])
            {
                GameObject.Find(Constants.CREWMATES_INVENTORY[i]).GetComponent<Button>().interactable = true;
                GameObject.Find(Constants.TEXT_INVENTORY[i]).GetComponent<TMP_Text>().text = "OWNED";
            }
            else
            {
                GameObject.Find(Constants.CREWMATES_INVENTORY[i]).GetComponent<Button>().interactable = false;
                GameObject.Find(Constants.TEXT_INVENTORY[i]).GetComponent<TMP_Text>().text = Constants.UNLOCKS_AT_INVENTORY + Constants.HIGHSCORE_THRESHOLDS[i].ToString();
            }
        }
    }

    public void selectCrewmate(int i)
    {
        PlayerPrefs.SetInt(Constants.SPRITE_SELECTED_KEY, i);
        PlayerPrefs.Save();
    }
}
