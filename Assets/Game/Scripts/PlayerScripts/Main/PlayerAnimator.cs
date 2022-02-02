using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField]
    PlayerScript playerScript;
    [SerializeField]
    Animator animator;


    //Sounds
    public AudioSource footStepSound;
    public AudioSource gunSound;

    // Update is called once per frame
    void Update()
    {
        if (playerScript.inputScript.isMovingRight == true || playerScript.inputScript.isMovingLeft == true || playerScript.inputScript.isMovingUp == true || playerScript.inputScript.isMovingDown == true)
        {
            animator.SetBool("Walk", true);
          
        } else
        {
            animator.SetBool("Walk", false);
        }

        if (animator.GetBool("Walk") == true && footStepSound.isPlaying == false)
        {
            footStepSound.Play();
        }
        else if (animator.GetBool("Walk") == false && footStepSound.isPlaying == true)
        {
            footStepSound.Stop();
        }

    }



    public void PlayerDeath()
    {
        animator.SetTrigger("Die");
        playerScript.inputScript.enabled = false;
        StartCoroutine(DeathAnim());

    }

    IEnumerator DeathAnim()
    {
        yield return new WaitForSeconds(1.2f);
        animator.enabled = false;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("SampleScene");
    }

    public void Shoot()
    {
        animator.SetTrigger("Crossbow Shoot Attack");
        gunSound.Play();
        StartCoroutine(playerScript.BulletShoot());
    }

}
