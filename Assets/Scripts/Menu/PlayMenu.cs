using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayMenu : MonoBehaviour
{
    public Text warning; 
    public static bool is_CueCard = false;
    public static bool is_OneOperator = false;
    public void Original()
    {
        is_CueCard = false;
        is_OneOperator = false;
        InitializeGame();
        LevelController.gameMode = Constants.ORIGINAL_GAMEMODE;
    }

    public void Addition()
    {
        is_OneOperator = true;
        InitializeGame();
        LevelController.gameMode = Constants.ADDITION_GAMEMODE;
    }

    public void Subtraction()
    {
        is_OneOperator = true;
        InitializeGame();
        LevelController.gameMode = Constants.SUBTRACTION_GAMEMODE;
    }

    public void Multiplication()
    {
        is_OneOperator = true;
        InitializeGame();
        LevelController.gameMode = Constants.MULTIPLICATION_GAMEMODE;
    }

    public void Division()
    {
        is_OneOperator = true;
        InitializeGame();
        LevelController.gameMode = Constants.DIVISION_GAMEMODE;
    }

    public void CueCards()
    {
        if (CueCardMenu.cardmap.Count > 0) 
        {
            is_CueCard = true;
            InitializeGame();
            LevelController.gameMode = Constants.CUE_CARDS_GAMEMODE;
        }
        else
        {
            warning.text = Constants.NO_CARDS_MSG;
        }
    }

    private void InitializeGame()
    {
        SceneManager.LoadScene(Constants.GAME_SCENE);
        PlayerMovement.hp = 5;
        Score.score = 0;
    }

}
