using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Player Script Reference
    [SerializeField]
    PlayerScript playerScript;
    public bool canMove;

    private WaitForSeconds movementDelay = new WaitForSeconds(.5f);


    //RayCast Information
    public int rayCastDistance = 1;
    public LayerMask wallLayer;
    private GameObject lastHitObject;
    public int pushBackForce;

 



    private void Start()
    {
        canMove = true;
     
    }


    private void Update()
    {
        if (playerScript != null)
        {
            if (canMove == true && !playerScript.inputScript.isShooting)
            {
                playerScript.rb.MovePosition(playerScript.rb.position + playerScript.inputScript.movement * playerScript.movementSpeed * Time.deltaTime);

                var ray = new Ray(this.transform.position, this.transform.forward);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, rayCastDistance, wallLayer))
                {
                    lastHitObject = hit.transform.gameObject;
                    playerScript.rb.AddForce(transform.forward * pushBackForce);
                    
                }
            }

            if (canMove == false)
            {
                StartCoroutine(TempMovementDelay());
            }
        } else
        {

        }

    }


    IEnumerator TempMovementDelay()
    {
        yield return movementDelay;
        canMove = true;
    }

   

}
