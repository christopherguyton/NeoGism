using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    private PlayerScript playerScript;
    public Text healthText;
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();

    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + playerScript.playerHealth.ToString();
    }
}
