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
    public float shootingDelay;
    private float meleeDelay;

    //Melee delay value
    public float currentMeleeDelay;


    //Shoot and Punch Variable Control
    private bool canShoot;
    private bool canMelee;


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
        meleeDelay = currentMeleeDelay;
        miniMap = GameObject.Find("MiniMapBorder");
        playerBullet = playerScript.bulletPrefab.GetComponent<PlayerBulletScript>();
    }

    // Update is called once per frame
    void Update()
    {

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

        if (meleeDelay == 0)
        {
            canMelee = true;
        } else if (meleeDelay > 0)
        {
            meleeDelay -= Time.deltaTime;
            canMelee = false;
        }
        if (meleeDelay <= 0)
        {
            meleeDelay = 0;
        }

        if (Input.GetKeyDown(punchKey) && isWalking == false && canMelee == true)
        {
            meleeDelay = currentMeleeDelay;
            playerScript.animatorScript.PunchAttack();
        }
      
    }


}

