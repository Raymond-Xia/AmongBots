using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{

    public static string[] sprites = new string[]
    {
        Constants.SKIN_0,
        Constants.SKIN_1,
    };

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
            i = sprites.Length - 1;
        }
        UpdateSprite();
        UpdateButton();
    }

    public void RightButton()
    {
        i++;
        if (i == sprites.Length)
        {
            i = 0;
        }
        UpdateSprite();
        UpdateButton();
    }

    public void BuyButton()
    {
        char[] owned = "000000000000".ToCharArray();
        if (PlayerPrefs.HasKey(Constants.SPRITE_OWNED_KEY))
        {
            owned = PlayerPrefs.GetString(Constants.SPRITE_OWNED_KEY).ToCharArray();
        }
        owned[i] = '1';
        PlayerPrefs.SetString(Constants.SPRITE_OWNED_KEY, new string(owned));
        PlayerPrefs.Save();
        UpdateButton();
    }

    private void UpdateSprite()
    {
        Sprite sprite = Resources.Load<Sprite>(sprites[i]);
        GameObject.Find(Constants.CREWMATE_OBJECT).GetComponent<Image>().sprite = sprite;
    }

    private void UpdateButton()
    {
        char[] owned = "000000000000".ToCharArray();
        if (PlayerPrefs.HasKey(Constants.SPRITE_OWNED_KEY))
        {
            owned = PlayerPrefs.GetString(Constants.SPRITE_OWNED_KEY).ToCharArray();
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
