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


    //Public Attributes 
   public float playerHealth = 10;
   internal float movementSpeed;
   public float walkSpeed = 5;
   public float runSpeed = 10;


    //Internal Attributes
    internal bool isDead;


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
        
    }



    public IEnumerator BulletShoot()
    {
        yield return new WaitForSeconds(.2f);
        GameObject bullet = Instantiate(bulletPrefab, shootTransform.transform.position, shootTransform.transform.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }





}
