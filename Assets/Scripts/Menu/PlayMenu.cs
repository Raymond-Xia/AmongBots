using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
    public void Original()
    {
        InitializeGame();
        LevelController.gameMode = Constants.ORIGINAL_GAMEMODE;
    }

    public void Addition()
    {
        InitializeGame();
        LevelController.gameMode = Constants.ADDITION_GAMEMODE;
    }

    public void Subtraction()
    {
        InitializeGame();
        LevelController.gameMode = Constants.SUBTRACTION_GAMEMODE;
    }

    public void Multiplication()
    {
        InitializeGame();
        LevelController.gameMode = Constants.MULTIPLICATION_GAMEMODE;
    }

    public void Division()
    {
        InitializeGame();
        LevelController.gameMode = Constants.DIVISION_GAMEMODE;
    }

    public void CueCards()
    {
        // to do
    }

    private void InitializeGame()
    {
        SceneManager.LoadScene(Constants.GAME_SCENE);
        PlayerMovement.hp = 5;
        Score.score = 0;
    }

}
