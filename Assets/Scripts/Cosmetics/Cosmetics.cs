using UnityEngine;

public class Cosmetics : MonoBehaviour
{
    public static Sprite UpdateSprite()
    {
        int selected = 0;
        if (PlayerPrefs.HasKey(Constants.SPRITE_SELECTED_KEY))
        {
            selected = PlayerPrefs.GetInt(Constants.SPRITE_SELECTED_KEY);
        }
        return Resources.Load<Sprite>(Constants.SPRITES[selected]);
    }

    public static Sprite UpdateSkin() 
    {
        int selected = 0;
        if (PlayerPrefs.HasKey(Constants.SKIN_SELECTED_KEY))
        {
            selected = PlayerPrefs.GetInt(Constants.SKIN_SELECTED_KEY);
        }
        return Resources.Load<Sprite>(Constants.SKINS[selected]);
    }
}
