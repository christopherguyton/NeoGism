using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    internal PlayerInput inputScript;
    [SerializeField]
    internal PlayerMovement movementScript;
    [SerializeField]
    internal PlayerCollision collisionScript;
    [SerializeField]
    internal PlayerAnimator animatorScript;


    //RigidBody
   internal Rigidbody rb;


    //WaitForSeconds Objects
    WaitForSeconds bulletDelay = new WaitForSeconds(.2f);


    //Public Attributes 
   public float maximumHealth;
   public float playerHealth;
   public float walkSpeed = 5;
   public float runSpeed = 10;


    //Internal Attributes
    internal bool isDead;
    internal int dataDiscsHeld;
    internal float movementSpeed;

    //Variables
    public GameObject bulletPrefab;
    public Transform shootTransform;
    [SerializeField] private float bulletSpeed;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        inputScript.enabled = true;
        animatorScript.enabled = true;
        movementSpeed = walkSpeed;
        playerHealth = maximumHealth;
        
    }

 



    public IEnumerator BulletShoot()
    {
        yield return bulletDelay;
        GameObject bullet = Instantiate(bulletPrefab, shootTransform.transform.position, shootTransform.transform.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }





}
