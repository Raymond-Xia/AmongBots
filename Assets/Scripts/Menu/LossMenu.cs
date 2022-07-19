using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LossMenu : MonoBehaviour
{
    public GameObject crewmate;
    public GameObject skin;
    void Start()
    {
        crewmate = GameObject.Find(Constants.CREWMATE_OBJECT);
        skin = GameObject.Find(Constants.SKIN_OBJECT);

        crewmate.GetComponent<Image>().sprite = Cosmetics.UpdateSprite();
        skin.GetComponent<Image>().sprite = Cosmetics.UpdateSkin();
        if (Answer.record.Count == 0)
        {
            Destroy(GameObject.Find("ReviewButton"));
        }
    }

    public void PlayButton()
    {
        Answer.resetRecord();
        SceneManager.LoadScene(Constants.GAME_SCENE);
        PlayerMovement.hp = 5;
    }

    public void ExitButton()
    {
        Answer.resetRecord();
        SceneManager.LoadScene(Constants.MENU_SCENE);
    }

}
