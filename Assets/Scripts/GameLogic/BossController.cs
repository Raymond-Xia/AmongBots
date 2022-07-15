using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject boss;
    public float bossY = 1600;
    public Transform canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator WaitAndSpawnBoss()
    {
        yield return new WaitForSeconds(10.0f);
        GameObject newBoss = Instantiate(boss, new Vector2(canvas.position.x, canvas.position.y + bossY), Quaternion.identity, canvas) as GameObject;
        newBoss.transform.SetSiblingIndex(1);
    }
}
