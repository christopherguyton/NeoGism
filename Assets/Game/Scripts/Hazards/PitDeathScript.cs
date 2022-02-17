using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitDeathScript : MonoBehaviour
{

    private PlayerScript playerScript;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerScript = collision.gameObject.GetComponent<PlayerScript>();
            playerScript.playerHealth = 0;
        }
    }
}
