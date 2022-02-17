using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoorScript : MonoBehaviour
{
    private Animator anim;
    private WaitForSeconds trapDoorWait = new WaitForSeconds(2f);

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("SteppedOn", true);
                
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(TrapDoorDelay());

        }
    }

    IEnumerator TrapDoorDelay()
    {
        yield return trapDoorWait;
        anim.SetBool("SteppedOn", false);
    }
}
