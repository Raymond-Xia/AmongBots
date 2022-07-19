using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Warning : MonoBehaviour
{
    public TMP_Text message;

    public void Acknowledge()
    {
        if (message.text == Constants.EPILEPSY_WARNING)
        {
            message.text = Constants.AGE_WARNING;
        }
        else
        {
            SceneManager.LoadScene(Constants.MENU_SCENE);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
