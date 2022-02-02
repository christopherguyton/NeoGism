using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //Player Script Reference
    [SerializeField]
    PlayerScript playerScript;



    //Movement Booleans
    internal bool isMovingRight;
    internal bool isMovingLeft;
    internal bool isMovingUp;
    internal bool isMovingDown;
    internal bool isNotMoving;


    //Action Booleans
    internal bool isShooting;
    //internal bool isWalking;
    //internal bool pressingRun;


    //KeyCode Variables
    private KeyCode rightKey = KeyCode.D;
    private KeyCode leftKey = KeyCode.A;
    private KeyCode upKey = KeyCode.W;
    private KeyCode downKey = KeyCode.S;
    private KeyCode shootKey = KeyCode.Z;
    private KeyCode runKey = KeyCode.LeftShift;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(rightKey))
        {
            isMovingRight = true;
      
  
        }
        else if (Input.GetKey(leftKey))
        {
            isMovingLeft = true;
       
        }
        else if (Input.GetKey(upKey))
        {
            isMovingUp = true;
        
        }
        else if (Input.GetKey(downKey))
        {
            isMovingDown = true;
    
        } else 
        {
            isNotMoving = true;
            isMovingRight = false;
            isMovingLeft = false;
            isMovingDown = false;
            isMovingUp = false;
      
        }

        if (Input.GetKeyDown(shootKey))
        {
            isShooting = true;
            playerScript.animatorScript.Shoot();
            
        }
        else 
        {
            isShooting = false;
        }
        
       
    }
}
