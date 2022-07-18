using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene(Constants.MENU_SCENE);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        LevelController.music.Pause();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        LevelController.music.UnPause();
    }
}
