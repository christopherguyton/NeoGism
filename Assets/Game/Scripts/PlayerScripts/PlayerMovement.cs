using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    PlayerScript playerScript;
    [SerializeField]
    Animator anim;
    //Component References


    //Variables



    private void Update()
    {
        if (playerScript.inputScript.isMovingRight == true)
        {
            anim.SetBool("Walk", true);
            MovePlayerRight();
        }
        else if (playerScript.inputScript.isMovingLeft == true)
        {
            anim.SetBool("Walk", true);
            MovePlayerLeft();
        }
        else if (playerScript.inputScript.isMovingUp == true)
        {
            anim.SetBool("Walk", true);
            MovePlayerUp();
        }
        else if (playerScript.inputScript.isMovingDown == true)
        {
            anim.SetBool("Walk", true);
            MovePlayerDown();
        }
        else if (playerScript.inputScript.isNotMoving == true)
        {
            anim.SetBool("Walk", false);
            StopMovement();
        }
    }
    // Update is called once per frame
   void MovePlayerRight() 
    {
        playerScript.rb.velocity = new Vector3(playerScript.movementSpeed, 0);
        transform.forward = playerScript.rb.velocity;
    }

   void MovePlayerLeft()
    {
        playerScript.rb.velocity = new Vector3(-playerScript.movementSpeed, 0);
        transform.forward = playerScript.rb.velocity;
    }

 void MovePlayerUp()
    {
        playerScript.rb.velocity = new Vector3(0, 0, playerScript.movementSpeed);
        transform.forward = playerScript.rb.velocity;
    }

    void MovePlayerDown()
    {
        playerScript.rb.velocity = new Vector3(0, 0, -playerScript.movementSpeed);
        transform.forward = playerScript.rb.velocity;
    }

    public void StopMovement()
    {
        playerScript.rb.velocity = new Vector3(0, 0);
    }
}
