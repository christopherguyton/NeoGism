using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAnimator : MonoBehaviour
{

    //Player Script Reference
    [SerializeField]
    PlayerScript playerScript;
    //Animator
    private Animator animator;


    //Sounds
    public AudioSource footStepSound;
    public AudioSource gunSound;
    public AudioSource damageSound;
    public AudioSource deathSound;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.inputScript.movement.x > 0 || playerScript.inputScript.movement.x < 0 || playerScript.inputScript.movement.z < 0 || playerScript.inputScript.movement.z > 0)
        {
            transform.forward = playerScript.inputScript.movement;
            animator.SetBool("Walk", true);
            playerScript.inputScript.isWalking = true;
        } else 
        {
            playerScript.inputScript.isWalking = false;
            animator.SetBool("Walk", false);
        }

        if (playerScript.inputScript.isRunning == true)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
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
        SceneManager.LoadScene(2);
    }

    public void Shoot()
    {
        animator.SetTrigger("Crossbow Shoot Attack");
        gunSound.Play();
        StartCoroutine(playerScript.BulletShoot());
    }


    public void PunchAttack()
    {

        animator.SetTrigger("Right Punch Attack");

    }

    public void TakeDamage()
    {
        animator.SetTrigger("Take Damage");
        damageSound.Play();


    }

}
