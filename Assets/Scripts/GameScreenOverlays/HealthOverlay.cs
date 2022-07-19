using UnityEngine;
using UnityEngine.UI;

public class HealthOverlay : MonoBehaviour
{
    public GameObject[] hearts = new GameObject[Constants.MAX_HP];

    // Update is called once per frame
    void Update()
    {
        // healthText.text = "HP: " + PlayerMovement.hp.ToString();
        foreach (Transform child in GameObject.Find(Constants.HEALTH_PANEL).transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        int x = 130;
        for (int i = 0; i < PlayerMovement.hp; i++)
        {
            hearts[i] = new GameObject();
            hearts[i].transform.parent = GameObject.Find(Constants.HEALTH_PANEL).transform;

            Sprite sprite = Resources.Load<Sprite>(Constants.HEART_SPRITE);
            hearts[i].AddComponent<Image>().sprite = sprite;
            RectTransform heartRectTransform = hearts[i].GetComponent<RectTransform>();
            heartRectTransform.transform.localScale = new Vector2(1.38f, 1.2f);
            heartRectTransform.transform.position = new Vector2(x, Screen.height - 350);
            hearts[i].SetActive(true);
            x += 150;
        }
    }
}
