using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletScript : MonoBehaviour
{

    //Bullet Shooting Delay
    public float bulletShootingDelay;
    public float bulletDamage;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
          
            collision.gameObject.GetComponent<EnemyCollision>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }
}
