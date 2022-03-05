using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateOpenScript : MonoBehaviour
{
    public Text gateOpenPrompt;

    private PlayerInput playerInput;
    private bool playerColliding;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerColliding = true;
            playerInput = other.GetComponent<PlayerInput>();
            gateOpenPrompt.gameObject.SetActive(true);
            gateOpenPrompt.text = "Press 'P' to Open"; 
        }
    }


    private void FixedUpdate()
    {
        if (playerColliding == true)
        {
           
            KeyCode openCommand = playerInput.punchKey;
            if (Input.GetKeyDown(openCommand))
            {
                GateOpen();
            }
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

    private void GateOpen()
    {
        gateOpenPrompt.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
