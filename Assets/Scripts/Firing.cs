using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    // function variables
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;

    // updates while game is playing
    private void Update()
    {
        // checks if a bullet has been fired and fires when detected as well as print out to console log
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
            Debug.Log("Fire");
        }
    }

    // fire function
    void Fire()
    {
        // this function creates and fires the bullet from the firePoint placed inside the player
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = firePoint.right * bulletSpeed;
        }

        // collider properties to ensure planet and bullet don't collide
        Collider2D bulletCollider = bullet.GetComponent<Collider2D>();
        Collider2D playerCollider = GetComponent<Collider2D>();
        if (bulletCollider != null && playerCollider != null)
        {
            Physics2D.IgnoreCollision(bulletCollider, playerCollider);
        }

        // marks any bullets made as clone for deletion
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.MarkAsClone();
        }
    }
}