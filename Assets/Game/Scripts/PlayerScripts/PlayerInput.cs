using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    [SerializeField]
    PlayerScript playerScript;


    internal bool isMovingRight;
    internal bool isMovingLeft;
    internal bool isMovingUp;
    internal bool isMovingDown;
    internal bool isNotMoving;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.D))
        {
            isMovingRight = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            isMovingLeft = true;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            isMovingUp = true;
        }
        else if (Input.GetKey(KeyCode.S))
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
        
       
    }
}
