using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Warning : MonoBehaviour
{
    public void Acknowledge()
    {
        SceneManager.LoadScene(Constants.MENU_SCENE);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
