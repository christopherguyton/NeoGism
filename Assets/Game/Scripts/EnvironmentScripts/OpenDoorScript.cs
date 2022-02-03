using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorScript : MonoBehaviour
{
    public GameObject door;
    public AudioSource doorOpenSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            doorOpenSound.Play();
            Destroy(door.gameObject);
            Destroy(gameObject);
        }
    }
}
