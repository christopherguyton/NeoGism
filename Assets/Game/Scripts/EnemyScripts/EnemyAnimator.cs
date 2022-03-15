using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField]
    internal EnemyScript enemyScript;


    //Wait For Seconds Objects
    WaitForSeconds deathFall = new WaitForSeconds(1.2f);
    WaitForSeconds disappear = new WaitForSeconds(.3f);

    //Animator Reference
    private Animator animator;


    //Bools
    internal bool isWalking;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (animator.GetBool("Walk"))
        {
            isWalking = true;
        }
    }

    public void EnemyDeath()
    {
        animator.SetTrigger("Die");
        enemyScript.isDead = true;
        StartCoroutine(DeathAnim());
    }

    IEnumerator DeathAnim()
    {
        yield return deathFall;
        animator.enabled = false;
        yield return disappear;
        gameObject.SetActive(false);
    }

    public void EnemyWalk()
    {
        if (!enemyScript.movementScript.playerInAttackRange && !enemyScript.movementScript.playerInSightRange) animator.SetBool("Walk", true);
        else if (!enemyScript.movementScript.playerInAttackRange && enemyScript.movementScript.playerInSightRange) animator.SetBool("Walk", true);
        else if (enemyScript.movementScript.playerInAttackRange && enemyScript.movementScript.playerInSightRange) animator.SetBool("Walk", false);

    }

    public void MeleeAttack()
    {
       
        animator.SetTrigger("Right Punch Attack");
      
    }

    public void RangedAttack()
    {

    }

    public void TakeDamage()
    {
        animator.SetTrigger("Take Damage");
        transform.position -= transform.forward;
    }

    public void Idle()
    {
        animator.SetTrigger("Idle");
    }
}
