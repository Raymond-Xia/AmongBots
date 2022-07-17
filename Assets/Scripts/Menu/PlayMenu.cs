using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayMenu : MonoBehaviour
{
    public Text warning; 

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
        if (CueCardMenu.cardmap.Count > 0) 
        {
            InitializeGame();
            LevelController.gameMode = Constants.CUE_CARDS_GAMEMODE;
        }
        else
        {
            warning.text = "MUST HAVE AT LEAST ONE CUE CARD TO PLAY!";
        }
    }

    private void InitializeGame()
    {
        SceneManager.LoadScene(Constants.GAME_SCENE);
        PlayerMovement.hp = 5;
        Score.score = 0;
    }

}
