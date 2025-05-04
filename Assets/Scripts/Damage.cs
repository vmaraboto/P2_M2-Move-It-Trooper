using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    // variables for the functions
    public int maxHealth = 30;
    private int currentHealth;
    public int damageAmount = 10;
    public int scoreValue = 10;
    public Image healthBar;
    public GameObject explosionEffect;

    // start function holding max health
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    // updateHealthBar of enemies
    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            float percent = (float)currentHealth / maxHealth;
            healthBar.rectTransform.localScale = new Vector3(percent, 1, 1);
        }
    }

    // takeDamage function which determines when the obstacle is taking damage
    public void TakeDamage(int damage)
    {
        // updates current health and prints it out to the console log and update health bar
        currentHealth -= damage;
        Debug.Log("Obstacle took " + damage + " damage. Health: " + currentHealth);
        UpdateHealthBar();

        // when health reaches 0 obstacle is destroyed
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // die function holding obstacle destroy command and console log output and creates explosion effect as well as updating the health bar
    void Die()
    {
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        Debug.Log("Obstacle destroyed.");
        Score.Instance.AddScore(scoreValue);
        Destroy(gameObject);
    }

    // onCollision function
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // detects when the obstacle is being hit by a bullet
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();

            if (bullet != null)
            {
                TakeDamage(bullet.damage);
                Destroy(collision.gameObject);
            }
        }

        // detects when the object has hit the player
        Life playerHealth = collision.gameObject.GetComponent<Life>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
        }
    }
}