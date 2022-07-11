using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static string[] sprites = new string[]
    {
        Constants.BLACK_CREWMATE,
        Constants.BLUE_CREWMATE,
        Constants.BROWN_CREWMATE,
        Constants.CYAN_CREWMATE,
        Constants.GREEN_CREWMATE,
        Constants.LIME_CREWMATE,
        Constants.ORANGE_CREWMATE,
        Constants.PINK_CREWMATE,
        Constants.PURPLE_CREWMATE,
        Constants.RED_CREWMATE,
        Constants.WHITE_CREWMATE,
        Constants.YELLOW_CREWMATE
    };

    public int i = 0;
    delegate void Cycle();

    void Start()
    {
        UpdateSprite();
        UpdateSkin();
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(Constants.GAME_SCENE);
        PlayerMovement.hp = 5;
        Score.score = 0;
    }

    public void UpdateSprite()
    {
        int selected = 3;
        if (PlayerPrefs.HasKey(Constants.SPRITE_SELECTED_KEY))
        {
            selected = PlayerPrefs.GetInt(Constants.SPRITE_SELECTED_KEY);
        }
        Sprite sprite = Resources.Load<Sprite>(sprites[selected]);
        GameObject.Find(Constants.CREWMATE_OBJECT).GetComponent<Image>().sprite = sprite;
    }

    public void UpdateSkin()
    {
        int selected = 0;
        if (PlayerPrefs.HasKey(Constants.SKIN_SELECTED_KEY))
        {
            selected = PlayerPrefs.GetInt(Constants.SKIN_SELECTED_KEY);
        }
        Sprite sprite = Resources.Load<Sprite>(Constants.SKINS[selected]);
        GameObject.Find(Constants.SKIN_OBJECT).GetComponent<Image>().sprite = sprite;
    }

    public void LeftButton()
    {
        Cycle cycle = () =>
        {
            i--;
            if (i < 0)
            {
                i = Constants.SKINS.Length - 1;
            }
        };
        SelectSkin(cycle);
    }

    public void RightButton()
    {
        Cycle cycle = () =>
        {
            i++;
            if (i == Constants.SKINS.Length)
            {
                i = 0;
            }
        };
        SelectSkin(cycle);
    }

    private void SelectSkin(Cycle cycle)
    {
        char[] owned = Constants.SKIN_OWNED_MASK.ToCharArray();
        if (PlayerPrefs.HasKey(Constants.SKIN_OWNED_KEY))
        {
            owned = PlayerPrefs.GetString(Constants.SKIN_OWNED_KEY).ToCharArray();
        }
        do
        {
            cycle();
        } while (owned[i] == '0');
        PlayerPrefs.SetInt(Constants.SKIN_SELECTED_KEY, i);
        PlayerPrefs.Save();
        UpdateSkin();
    }
}
