using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NukeButton : MonoBehaviour
{
    public static Button nukeButton;

    // Start is called before the first frame update
    void Start()
    {
        nukeButton = GameObject.FindGameObjectWithTag("NukeButton").GetComponent<Button>();       
        nukeButton.transform.SetPositionAndRotation(new Vector3(150, 200, 0), Quaternion.identity);
        nukeButton.interactable = false;
    }

    public static void activateButton()
    {
        nukeButton.interactable = true;
    }

    public void nukeEffect()
    {
        var missiles = GameObject.FindGameObjectsWithTag("Missile");

        foreach (GameObject target in missiles)
        {
            GameObject.Destroy(target);
        }

        nukeButton.interactable = false;
    }
}
