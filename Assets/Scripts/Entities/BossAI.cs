using System.Collections;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public Vector2 targetPosition;
    public float speed;
    public GameObject mathQuestion;
    public GameObject cueCardQuestion;
    public GameObject explosion;
    float explosionDuration = 1.5f;
    Transform canvas;
    GameObject newQuestion;
    bool askQuestion, questionAsked;
    public AudioSource explosionSound;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find(Constants.CANVAS_OBJECT).transform;
        targetPosition = new Vector2(canvas.position.x, canvas.position.y + 400);
        askQuestion = false;
        questionAsked = false;
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
            GameObject questionPrefab;
            float questionY;
            if (LevelController.gameMode == Constants.CUE_CARDS_GAMEMODE) 
            {
                questionPrefab = cueCardQuestion;
                questionY = 50;
            }
            else 
            {
                questionPrefab = mathQuestion;
                questionY = -140;
            }
            
            newQuestion = Instantiate(questionPrefab, new Vector2(canvas.position.x, canvas.position.y + questionY), Quaternion.identity, canvas) as GameObject;
            newQuestion.transform.SetSiblingIndex(2);
            questionAsked = true;
        }

    }

    public void DestroyAnimation()
    {
        explosion.SetActive(true);
        explosionSound.Play();
        StartCoroutine(HideBoss(explosionDuration));
    }

    IEnumerator HideBoss(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
