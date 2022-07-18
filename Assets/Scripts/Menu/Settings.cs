using UnityEngine;

public class Settings : MonoBehaviour
{
    public void ResetButton()
    {
        PlayerPrefs.SetString(Constants.SPRITE_OWNED_KEY, Constants.SPRITE_OWNED_MASK);
        PlayerPrefs.SetInt(Constants.SPRITE_SELECTED_KEY, 0);
        PlayerPrefs.SetString(Constants.SKIN_OWNED_KEY, Constants.SKIN_OWNED_MASK);
        PlayerPrefs.SetInt(Constants.SKIN_SELECTED_KEY, 0);
        int[] ints = { 0, 0, 0, 0, 0 };
        PlayerPrefs.SetString(Constants.SCORES_TOPSCORES, string.Join("/n", ints));
        PlayerPrefs.Save();
    }
}
