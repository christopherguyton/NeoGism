using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField]
    internal EnemyScript enemyScript;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void AttackPlayer()
    {
        if (enemyScript.movementScript.playerInAttackRange)
        {
            player.GetComponent<PlayerAnimator>().TakeDamage();

        }

    }

    public void TakeDamage(float damage)
    {
        if (enemyScript.enemyHealth > 0)
        {
            enemyScript.enemyHealth -= damage;
            enemyScript.animatorScript.TakeDamage();
        }
    }
}

