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
        if (playerScript.inputScript.isMovingRight == true)
        {
        
            MovePlayerRight();
        }
        else if (playerScript.inputScript.isMovingLeft == true)
        {
          
            MovePlayerLeft();
        }
        else if (playerScript.inputScript.isMovingUp == true)
        {
        
            MovePlayerUp();
        }
        else if (playerScript.inputScript.isMovingDown == true)
        {
          
            MovePlayerDown();
        }
        else if (playerScript.inputScript.isNotMoving == true)
        {
            
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

    void StopMovement()
    {
        playerScript.rb.velocity = new Vector3(0, 0);
    }

   

}
