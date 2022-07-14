using UnityEngine;
using UnityEngine.UI;

public class EjectedPlayer : MonoBehaviour
{
    public float rotationAngle = 0.0f;
    public float centerX;
    public GameObject crewmate;
    public GameObject skin;

    // Start is called before the first frame update
    void Start()
    {
        crewmate = GameObject.Find(Constants.CREWMATE_OBJECT);
        skin = GameObject.Find(Constants.SKIN_OBJECT);
        crewmate.transform.SetPositionAndRotation(new Vector3(-100, Screen.height - (Screen.height / 6), 0), Quaternion.identity);
        skin.transform.SetPositionAndRotation(new Vector3(-100, Screen.height - (Screen.height / 6), 0), Quaternion.identity);
        centerX = Screen.width / 2;

        crewmate.GetComponent<Image>().sprite = Cosmetics.UpdateSprite();
        skin.GetComponent<Image>().sprite = Cosmetics.UpdateSkin();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < centerX)
        {
            transform.position = new Vector2(transform.position.x + 1f, transform.position.y);
            skin.transform.position = new Vector2(skin.transform.position.x + 1f, skin.transform.position.y);
        }

        rotationAngle += 0.5f;

        Quaternion target = Quaternion.Euler(0, 0, rotationAngle);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 3.0f);
        skin.transform.rotation = Quaternion.Slerp(skin.transform.rotation, target, Time.deltaTime * 3.0f);

        if (rotationAngle >= 360f)
        {
            rotationAngle = 0f;
        }
    }
}
