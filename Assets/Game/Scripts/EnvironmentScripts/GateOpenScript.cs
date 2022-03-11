using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateOpenScript : MonoBehaviour
{

    
    public Text gateOpenPrompt;

    //Player Script Reference
    private PlayerInput playerInput;
    private PlayerScript playerScript;



    //Bools
    public bool keyCardNeeded;
    internal bool playerColliding;


    //Key Variable Type
    public string keyCardColor;
 

    private void OnTriggerEnter(Collider other)
    {
        playerScript = other.GetComponent<PlayerScript>();

        if (other.gameObject.CompareTag("Player") && !keyCardNeeded)
        {
            playerColliding = true;
            playerInput = other.GetComponent<PlayerInput>();
            gateOpenPrompt.gameObject.SetActive(true);
            gateOpenPrompt.text = "Press 'P' to Open"; 
        }

        else if (other.gameObject.CompareTag("Player") && keyCardNeeded)
        {
            playerColliding = true;
            playerInput = other.GetComponent<PlayerInput>();
            gateOpenPrompt.gameObject.SetActive(true);
            gateOpenPrompt.text = "You need the " + keyCardColor + " keycard";
           
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerColliding = false;
            gateOpenPrompt.gameObject.SetActive(false);
        }
    }


  public void Update()
    {


            if (gameObject != null)
            {
                if (playerColliding == true)
                {
                    KeyCode openCommand = playerInput.punchKey;
                    if (Input.GetKeyDown(openCommand) && !keyCardNeeded)
                    {
                        GateOpen();
                    }

                     if (Input.GetKeyDown(openCommand) && keyCardNeeded)
                    {
                        gateOpenPrompt.text = "You don't have the " + keyCardColor + " keycard";
                    } 
                 if (Input.GetKeyDown(openCommand) && keyCardNeeded && playerScript.holdingKey)
                {
                    GateOpen();
                }

                }
            
        }
        }


       public void GateOpen()
    {
        gateOpenPrompt.gameObject.SetActive(false);
        gameObject.SetActive(false);
        if (playerScript.holdingKey)
        {
            playerScript.holdingKey = !playerScript.holdingKey;
        }
    }
}
