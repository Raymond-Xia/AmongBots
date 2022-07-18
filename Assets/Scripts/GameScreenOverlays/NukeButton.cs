using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NukeButton : MonoBehaviour
{
    public static Button nukeButton;
    public Transform nukeFrame;
    public Sprite disabled;
    public Sprite active;

    // Start is called before the first frame update
    void Start()
    {
        nukeButton = GameObject.FindGameObjectWithTag(Constants.NUKEBUTTON_TAG).GetComponent<Button>();       
        nukeButton.transform.SetPositionAndRotation(new Vector3(150, 200, 0), Quaternion.identity);
        nukeButton.interactable = false;
        nukeFrame.transform.SetPositionAndRotation(new Vector3(150, 200, 0), Quaternion.identity);        
    }

    public void activateButton()
    {
        nukeButton.interactable = true;
        gameObject.GetComponent<Image>().sprite = active;
    }

    public void nukeEffect()
    {
        var missiles = GameObject.FindGameObjectsWithTag(Constants.MISSILE_TAG);

        foreach (GameObject target in missiles)
        {
            GameObject.Destroy(target);
        }

        nukeButton.interactable = false;
        gameObject.GetComponent<Image>().sprite = disabled;
    }
}
