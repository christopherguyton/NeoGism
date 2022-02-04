using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //Player Script Reference
    [SerializeField]
    PlayerScript playerScript;



    //Movement Variable
    internal Vector3 movement;



    //Action Booleans
    internal bool isShooting;
    internal bool isWalking;
    internal bool isRunning;


    //KeyCodeVariables
    private KeyCode shootKey = KeyCode.Z;
    private KeyCode runKey = KeyCode.LeftShift;




    // Update is called once per frame
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
 

        if (Input.GetKeyDown(shootKey) && isWalking == false)
        {
            isShooting = true;
            playerScript.animatorScript.Shoot();

        }
        else
        {
            isShooting = false;
        }

        if (Input.GetKeyDown(runKey) && isWalking == true)
        {
            isRunning = true;
            playerScript.movementSpeed = playerScript.runSpeed;
        } else if (Input.GetKeyUp(runKey))
        {
            isRunning = false;
            playerScript.movementSpeed = playerScript.walkSpeed;
        }



    }
}
