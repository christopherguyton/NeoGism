using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateCloseScript : MonoBehaviour
{
    public GameObject gateToClose;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gateToClose.SetActive(true);
            Destroy(gameObject);
        }
    }

}
