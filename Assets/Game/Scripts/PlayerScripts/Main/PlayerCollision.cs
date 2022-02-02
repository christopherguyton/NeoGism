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
       
        }
    }

    private void Update()
    {
        if (playerScript.playerHealth <= 0)
        {
            playerScript.isDead = true;
            if (playerScript.isDead)
            {
                playerScript.animatorScript.PlayerDeath();

            }
        }
    }
}
