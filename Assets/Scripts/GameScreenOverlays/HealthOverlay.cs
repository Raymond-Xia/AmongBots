using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthOverlay : MonoBehaviour
{
    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "HP: " + PlayerMovement.hp.ToString();
    }
}
