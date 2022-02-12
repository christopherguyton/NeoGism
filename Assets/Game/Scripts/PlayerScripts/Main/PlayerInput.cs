using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    //Player Script Reference
    [SerializeField]
    PlayerScript playerScript;

    //Input Delay

    private PlayerBulletScript playerBullet;
    private float shootingDelay;
    private bool canShoot;
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
    private KeyCode punchKey = KeyCode.P;
    private KeyCode runKey = KeyCode.LeftShift;
    private KeyCode toggleMiniMapKey = KeyCode.M;


    private void Start()
    {
        miniMap = GameObject.Find("MiniMapBorder");
        playerBullet = playerScript.bulletPrefab.GetComponent<PlayerBulletScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(shootingDelay);

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
 
        if (shootingDelay == 0)
        {
            canShoot = true;
        } else if (shootingDelay > 0)
        {
            shootingDelay -= Time.deltaTime;
            canShoot = false;
        }
        if (shootingDelay <= 0)
        {
            shootingDelay = 0;
        }

        if (Input.GetKeyDown(shootKey) && isWalking == false && canShoot == true)
        {
            isShooting = true;
            shootingDelay = playerBullet.bulletShootingDelay;
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

        if (Input.GetKeyDown(punchKey))
        {
            playerScript.animatorScript.PunchAttack();
        }

    }


}

