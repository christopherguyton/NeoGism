using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Player Script Reference
    [SerializeField]
    PlayerScript playerScript;
    public bool canMove;

    private WaitForSeconds movementDelay = new WaitForSeconds(.5f);


    private void Start()
    {
        canMove = true;
    }


    private void Update()
    {
        if (playerScript != null)
        {
            if (canMove == true && !playerScript.inputScript.isShooting)
            {
                playerScript.rb.MovePosition(playerScript.rb.position + playerScript.inputScript.movement * playerScript.movementSpeed * Time.deltaTime);
            }

            if (canMove == false)
            {
                StartCoroutine(TempMovementDelay());
            }
        } else
        {

        }

    }


    IEnumerator TempMovementDelay()
    {
        yield return movementDelay;
        canMove = true;
    }

   

}
