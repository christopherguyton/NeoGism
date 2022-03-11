using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLockedGateScript : GateOpenScript
{
    //Enemy Controller Array
    public List<GameObject> enemyLockedArray;
    // Update is called once per frame
    new void Update()
    {
        base.Update();

        if (enemyLockedArray != null)
        {
            foreach (GameObject enemy in enemyLockedArray.ToArray())
            {
                EnemyScript enemyScript = enemy.GetComponent<EnemyScript>();

                if (enemyScript.enemyHealth <= 0)
                {
                    enemyLockedArray.Remove(enemy);
                }
            }

            if (enemyLockedArray.Count <= 0)
            {
                Destroy(gameObject);
            }
        }


     
    }
}
