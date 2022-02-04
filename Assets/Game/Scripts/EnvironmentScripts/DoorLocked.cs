using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorLocked : MonoBehaviour
{

    public Text cantEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cantEnter.text = "Find The Pad To Unlock The Door";
            cantEnter.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cantEnter.gameObject.SetActive(false);
        }
    }

}
