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


   internal Rigidbody rb;
   public float movementSpeed = 5;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }


}
