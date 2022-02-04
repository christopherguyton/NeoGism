using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    //Player Script Reference
    [SerializeField]
    PlayerScript playerScript;


    //MiniMap Reference
    private GameObject miniMap;


    //Movement Variable
    internal Vector3 movement;



    //Action Booleans
    internal bool isShooting;
    internal bool isWalking;
    internal bool isRunning;


    //KeyCodeVariables
    private KeyCode shootKey = KeyCode.Z;
    private KeyCode runKey = KeyCode.LeftShift;
    private KeyCode toggleMiniMapKey = KeyCode.M;


    private void Start()
    {
        miniMap = GameObject.Find("MiniMapBorder");
    }

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

        if (Input.GetKeyDown(toggleMiniMapKey))
        {
            miniMap.gameObject.SetActive(!miniMap.gameObject.activeInHierarchy);
        }

    }
}
