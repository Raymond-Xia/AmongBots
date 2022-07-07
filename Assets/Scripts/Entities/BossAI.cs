using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public Vector2 targetPosition;
    public float speed;
    public GameObject question;
    public GameObject explosion;
    float questionY = -40;
    float explosionDuration = 1.5f;
    Transform canvas;
    GameObject newQuestion;
    bool askQuestion, questionAsked;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find(Constants.CANVAS_OBJECT).transform;
        targetPosition = new Vector2(canvas.position.x, canvas.position.y + 400);
        askQuestion = false;
        questionAsked = false;
        explosion = GameObject.Find(Constants.EXPLOSION_OBJECT);
        explosion.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector2)transform.position != targetPosition) // entrance animation
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else // ask question when reached position
        {
            askQuestion = true;
        }

        if (askQuestion && !questionAsked) // create question if question not already asked
        {
            newQuestion = Instantiate(question, new Vector2(canvas.position.x, canvas.position.y + questionY), Quaternion.identity, canvas) as GameObject;
            questionAsked = true;
        }

    }

    public void DestroyAnimation()
    {
        explosion.SetActive(true);
        StartCoroutine(HideBoss(explosionDuration));
    }

    IEnumerator HideBoss(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
