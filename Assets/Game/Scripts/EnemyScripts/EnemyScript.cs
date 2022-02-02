using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    internal EnemyAnimator animatorScript;
    [SerializeField]
    internal EnemyCollision collisionScript;


    

    //Enemy Attributes
    public float enemyHealth = 2;
    public float enemyMoveSpeed;

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
