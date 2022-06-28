using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ImpostorText : MonoBehaviour
{
    public TMP_Text impostorText;
    public string gameOverMessage;
    public int textIterator;
    public float centerX;
    public GameObject player;
    public bool runCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        impostorText = GetComponent<TMP_Text>();
        gameOverMessage = "You were not The Impostor";
        textIterator = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x >= centerX && !runCoroutine) 
        {
            runCoroutine = true;
            StartCoroutine(DisplayMessage(0.1f));
        }
    }

    IEnumerator DisplayMessage(float delay) 
    {
        while (impostorText.text != gameOverMessage) 
        {
            impostorText.text += gameOverMessage[textIterator];
            textIterator += 1;
            yield return new WaitForSeconds(delay);
        }
    }
}
