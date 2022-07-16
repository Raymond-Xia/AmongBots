using System.Collections;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    public GameObject hpPower;
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

    public void SpawnHpPowerup()
    {
        StartCoroutine(WaitAndSpawnHpPowerup());
    }

    public IEnumerator WaitAndSpawnHpPowerup()
    {
        yield return new WaitForSeconds(2.0f);
        GameObject healthPowerup = Instantiate(hpPower, new Vector2(canvas.position.x, canvas.position.y), Quaternion.identity, canvas) as GameObject;
        FindObjectOfType<HealthPowerup>().DestroyPowerup();
    }
}
