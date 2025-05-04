using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    // function variables
    public int maxHealth = 100;
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        SetMaxHealth(maxHealth);
    }

    // determine and restart max health when game is started
    public void SetMaxHealth(int health)
    {
        maxHealth = health;
        currentHealth = maxHealth;
    }

    // takeDamage function which determines when the player takes damage and prints out damage log to consolo log
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Player took damage: " + amount + ", current health: " + currentHealth);

        // determines if player has died
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // die function
    private void Die()
    {
        // print out player has died to console log and destorys the player
        Debug.Log("Player has died.");
        gameObject.SetActive(false);
    }
}
