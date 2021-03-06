using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    internal EnemyAnimator animatorScript;
    [SerializeField]
    internal EnemyCollision collisionScript;
    [SerializeField]
    internal EnemyMovement movementScript;

    

    //Enemy Attributes
    public float enemyHealth;

    internal bool isDead;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            animatorScript.EnemyDeath();
        }
    }
}
