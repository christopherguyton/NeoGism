using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStart : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        Instantiate(player, transform.position, transform.rotation);
    }
}
