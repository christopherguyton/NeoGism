using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoorScript : MonoBehaviour
{

    //DoorVariables
    public GameObject door;
    public AudioSource doorOpenSound;


    //Data Discs Needed to Complete the level
    public int dataDiscsNeeded;


    //Player Script Reference
    private PlayerScript playerScript;


    //UI Reference
    public Text notEnoughDiscs;


    private void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           if (playerScript.dataDiscsHeld == dataDiscsNeeded)
            {
                doorOpenSound.Play();
                Destroy(door.gameObject);
                StartCoroutine(DestroyPad());
            } else
            {
                notEnoughDiscs.gameObject.SetActive(true);
                notEnoughDiscs.text = "You Need " + dataDiscsNeeded + " data discs to Unlock the door";
               
            }
     
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            notEnoughDiscs.gameObject.SetActive(false);
        }
    }

    IEnumerator DestroyPad()
    {
        yield return new WaitForSeconds(.2f);
        Destroy(gameObject);
    }
}
