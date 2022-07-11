using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public int i = 0;

    void Start()
    {
        i = 0;
        UpdateSprite();
        UpdateButton();
    }

    public void UpdateStart()
    {
        i = 0;
        UpdateSprite();
        UpdateButton();
    }

    public void LeftButton()
    {
        i--;
        if (i < 0)
        {
            i = Constants.SKINS.Length - 1;
        }
        UpdateSprite();
        UpdateButton();
    }

    public void RightButton()
    {
        i++;
        if (i == Constants.SKINS.Length)
        {
            i = 0;
        }
        UpdateSprite();
        UpdateButton();
    }

    public void BuyButton()
    {
        char[] owned = Constants.SKIN_OWNED_MASK.ToCharArray();
        if (PlayerPrefs.HasKey(Constants.SKIN_OWNED_KEY))
        {
            owned = PlayerPrefs.GetString(Constants.SKIN_OWNED_KEY).ToCharArray();
        }
        owned[i] = '1';
        PlayerPrefs.SetString(Constants.SKIN_OWNED_KEY, new string(owned));
        PlayerPrefs.Save();
        UpdateButton();
    }

    private void UpdateSprite()
    {
        Sprite sprite = Resources.Load<Sprite>(Constants.SKINS[i]);
        GameObject.Find(Constants.CREWMATE_OBJECT).GetComponent<Image>().sprite = sprite;
    }

    private void UpdateButton()
    {
        char[] owned = Constants.SKIN_OWNED_MASK.ToCharArray();
        if (PlayerPrefs.HasKey(Constants.SKIN_OWNED_KEY))
        {
            owned = PlayerPrefs.GetString(Constants.SKIN_OWNED_KEY).ToCharArray();
        }
        if (owned[i].Equals('1'))
        {
            GameObject.Find(Constants.BUY_BUTTON_SHOP).GetComponent<Button>().interactable = false;
            GameObject.Find(Constants.BUY_TEXT_SHOP).GetComponent<TMP_Text>().text = "OWNED";
        }
        else
        {
            GameObject.Find(Constants.BUY_BUTTON_SHOP).GetComponent<Button>().interactable = true;
            GameObject.Find(Constants.BUY_TEXT_SHOP).GetComponent<TMP_Text>().text = "BUY";
        }
    }
}
