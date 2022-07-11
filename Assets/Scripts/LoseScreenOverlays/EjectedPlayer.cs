using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EjectedPlayer : MonoBehaviour
{
    public float rotationAngle = 0.0f;
    public float centerX;
    public GameObject crewmate;
    public static string[] sprites = new string[]
    {
        Constants.BLACK_CREWMATE,
        Constants.BLUE_CREWMATE,
        Constants.BROWN_CREWMATE,
        Constants.CYAN_CREWMATE,
        Constants.GREEN_CREWMATE,
        Constants.LIME_CREWMATE,
        Constants.ORANGE_CREWMATE,
        Constants.PINK_CREWMATE,
        Constants.PURPLE_CREWMATE,
        Constants.RED_CREWMATE,
        Constants.WHITE_CREWMATE,
        Constants.YELLOW_CREWMATE
    };
    // Start is called before the first frame update
    void Start()
    {
        crewmate = GameObject.Find(Constants.CREWMATE_OBJECT);
        crewmate.transform.SetPositionAndRotation(new Vector3(-100, Screen.height - (Screen.height / 6), 0), Quaternion.identity);
        centerX = Screen.width / 2;

        UpdateSprite();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < centerX)
        {
            transform.position = new Vector2(transform.position.x + 1f, transform.position.y);
        }

        rotationAngle += 0.5f;

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
        if (PlayerPrefs.HasKey(Constants.SPRITE_SELECTED_KEY))
        {
            selected = PlayerPrefs.GetInt(Constants.SPRITE_SELECTED_KEY);
        }
        Sprite sprite = Resources.Load<Sprite>(sprites[selected]);
        GameObject.Find(Constants.CREWMATE_OBJECT).GetComponent<Image>().sprite = sprite;
    }
}
