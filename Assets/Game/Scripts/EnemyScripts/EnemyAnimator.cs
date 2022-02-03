using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField]
    internal EnemyScript enemyScript;

    //Animator Reference
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

 

    public void EnemyDeath()
    {
        animator.SetTrigger("Die");
        enemyScript.isDead = true;
        StartCoroutine(DeathAnim());
    }

    IEnumerator DeathAnim()
    {
        yield return new WaitForSeconds(1.2f);
        animator.enabled = false;
        yield return new WaitForSeconds(.3f);
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
}
