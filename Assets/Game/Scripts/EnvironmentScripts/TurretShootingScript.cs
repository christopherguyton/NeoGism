using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShootingScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootTransform;

    public AudioSource shootingSound;

   [SerializeField] private float shootingTimer = 3f;
   [SerializeField]private float bulletSpeed = 10f;

    public void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootTransform.transform.position, shootTransform.transform.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse) ;
        shootingSound.Play();
    }

    private void Update()
    {
        shootingTimer -= Time.deltaTime;
        if (shootingTimer <= 0)
        {
            shootingTimer = 3f;
            ShootBullet();
            
        }

      
        
    }

}
