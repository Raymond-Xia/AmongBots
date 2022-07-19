using System.Collections;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    public GameObject hpPower;
    public GameObject nukePower;
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
        healthPowerup.transform.SetSiblingIndex(4);
        FindObjectOfType<HealthPowerup>().DestroyPowerup();
    }

    public void SpawnNukePowerup()
    {
        StartCoroutine(WaitAndSpawnNukePowerup());
    }

    public IEnumerator WaitAndSpawnNukePowerup()
    {
        yield return new WaitForSeconds(2.0f);
        GameObject nukePowerup = Instantiate(nukePower, new Vector2(canvas.position.x, canvas.position.y), Quaternion.identity, canvas) as GameObject;
        nukePowerup.transform.SetSiblingIndex(4);
        FindObjectOfType<NukePowerup>().DestroyPowerup();
    }
}
