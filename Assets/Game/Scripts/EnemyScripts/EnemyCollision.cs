using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField]
    internal EnemyScript enemyScript;

    private GameObject player;


    public float enemyDamageGiven;
    public AudioSource damageSound;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void AttackPlayer()
    {
        if (enemyScript.movementScript.playerInAttackRange)
        {
            player.GetComponent<PlayerCollision>().TakeDamage(enemyDamageGiven);

        }

    }

    public void TakeDamage(float damage)
    {
        if (enemyScript.enemyHealth > 0)
        {
            enemyScript.enemyHealth -= damage;
            damageSound.Play();
            enemyScript.animatorScript.TakeDamage();
        }
    }
}

