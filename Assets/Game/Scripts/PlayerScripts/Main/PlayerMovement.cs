using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Player Script Reference
    [SerializeField]
    PlayerScript playerScript;




    private void Update()
    {

        playerScript.rb.MovePosition(playerScript.rb.position + playerScript.inputScript.movement * playerScript.movementSpeed * Time.deltaTime);

    }




   

}
