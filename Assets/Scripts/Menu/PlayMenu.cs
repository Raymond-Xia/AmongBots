using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayMenu : MonoBehaviour
{
    public Text warning;
    public static bool is_CueCard = false;
    public static bool is_addition = false;
    public static bool is_subtraction = false;
    public static bool is_multiplication = false;
    public static bool is_division = false;

    public void ResetMode()
    {
        is_CueCard = false;
        is_addition = false;
        is_subtraction = false;
        is_multiplication = false;
        is_division = false;
    }

    public void Original()
    {
        ResetMode();
        InitializeGame();
        LevelController.gameMode = Constants.ORIGINAL_GAMEMODE;
    }

    public void Addition()
    {
        ResetMode();
        is_addition = true;
        InitializeGame();
        LevelController.gameMode = Constants.ADDITION_GAMEMODE;
    }

    public void Subtraction()
    {
        ResetMode();
        is_subtraction = true;
        InitializeGame();
        LevelController.gameMode = Constants.SUBTRACTION_GAMEMODE;
    }

    public void Multiplication()
    {
        ResetMode();
        is_multiplication = true;
        InitializeGame();
        LevelController.gameMode = Constants.MULTIPLICATION_GAMEMODE;
    }

    public void Division()
    {
        ResetMode();
        is_division = true;
        InitializeGame();
        LevelController.gameMode = Constants.DIVISION_GAMEMODE;
    }

    public void CueCards()
    {
        if (CueCardMenu.cardmap.Count > 0)
        {
            ResetMode();
            is_CueCard = true;
            InitializeGame();
            LevelController.gameMode = Constants.CUE_CARDS_GAMEMODE;
        }
        else
        {
            warning.text = Constants.NO_CARDS_MSG;
        }
    }

    public static void InitializeGame()
    {
        SceneManager.LoadScene(Constants.GAME_SCENE);
        PlayerMovement.hp = Constants.MAX_HP;
        PlayerMovement.invulnerable = false;
        Score.score = 0;
    }

}
