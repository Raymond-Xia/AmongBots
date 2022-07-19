using UnityEngine;
using UnityEngine.SceneManagement;

public class ReviewMenu : MonoBehaviour
{
    public void ExitButton()
    {
        Answer.resetRecord();
        SceneManager.LoadScene(Constants.MENU_SCENE);
    }

}
