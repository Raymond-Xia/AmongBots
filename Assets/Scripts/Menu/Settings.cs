using UnityEngine;
using System.Collections;
using TMPro;

public class Settings : MonoBehaviour
{
    public void ResetButton()
    {
        PlayerPrefs.DeleteAll();
        StartCoroutine(Confirmation());
    }

    private IEnumerator Confirmation()
    {
        GameObject.Find(Constants.CONFIRMATION_TEXT).GetComponent<TMP_Text>().text = Constants.CONFIRMATION_DATA;
        yield return new WaitForSeconds(2);
        GameObject.Find(Constants.CONFIRMATION_TEXT).GetComponent<TMP_Text>().text = "";
    }
}
