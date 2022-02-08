using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    PlayerScript playerScript;
    private BoxCollider col;

    private void Start()
    {
        col = GetComponent<BoxCollider>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            playerScript.playerHealth -= 2;
            playerScript.animatorScript.TakeDamage();
        }

        if (collision.gameObject.tag == "Data Disc")
        {
            playerScript.dataDiscsHeld++;
        }
        if(collision.gameObject.tag == "Health Pick Up" && playerScript.playerHealth < playerScript.maximumHealth)
        {
            float healthGiven = collision.gameObject.GetComponent<ItemCollect>().healthGiven;
            playerScript.playerHealth += healthGiven;
            if (playerScript.playerHealth > playerScript.maximumHealth)
            {
                playerScript.playerHealth = playerScript.maximumHealth;
            }
        } else if (collision.gameObject.tag == "Health Pick Up" && playerScript.playerHealth == playerScript.maximumHealth)
        {
         
            Debug.Log("You are already at Max Health");
        }
    }



    private void Update()
    {
        if (playerScript.playerHealth <= 0)
        {
            playerScript.playerHealth = 0;
            playerScript.isDead = true;
            if (playerScript.isDead)
            {
                playerScript.animatorScript.PlayerDeath();

            }
        }
    }
}
