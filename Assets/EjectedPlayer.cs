using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EjectedPlayer : MonoBehaviour
{
    public float rotationAngle = 0.0f;
    public static float currentX = 0f;
    public float centerX;
    public static string[] sprites = new string[]
    {
        "Sprites/CrewmateBlack",
        "Sprites/CrewmateBlue",
        "Sprites/CrewmateBrown",
        "Sprites/CrewmateCyan",
        "Sprites/CrewmateGreen",
        "Sprites/CrewmateLime",
        "Sprites/CrewmateOrange",
        "Sprites/CrewmatePink",
        "Sprites/CrewmatePurple",
        "Sprites/CrewmateRed",
        "Sprites/CrewmateWhite",
        "Sprites/CrewmateYellow"
    };
    // Start is called before the first frame update
    void Start()
    {
        UpdateSprite();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < centerX) 
        {
            transform.position = new Vector2(transform.position.x + 1f, transform.position.y);
        }
        else 
        {
            currentX = centerX;    
        }

        rotationAngle += 1.0f;

        Quaternion target = Quaternion.Euler(0, 0, rotationAngle);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 3.0f);
        
        if (rotationAngle >= 360f) 
        {
            rotationAngle = 0f;
        }
    }

    private void UpdateSprite()
    {
        int selected = 3;
        if (PlayerPrefs.HasKey("selected"))
        {
            selected = PlayerPrefs.GetInt("selected");
        }
        Sprite sprite = Resources.Load<Sprite>(sprites[selected]);
        GameObject.Find("Player").GetComponent<Image>().sprite = sprite;
    }
}
