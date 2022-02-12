using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    private PlayerScript playerScript;


    //Script Variables
    private float weaponDelay;


    //Text Objects
    public Text healthText;
    public Text dataDiscs;
    public Text weaponCoolDown;
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        
    }

    // Update is called once per frame
    void Update()
    {

        
        //UI text Updates
        healthText.text = "Health: " + playerScript.playerHealth.ToString();
        dataDiscs.text = "Data Discs: " + playerScript.dataDiscsHeld.ToString();
        weaponCoolDown.text = "Weapon Cool Down: " + Mathf.Round(playerScript.inputScript.shootingDelay * 100f).ToString();
    }
}
