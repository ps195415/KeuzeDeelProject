using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f; // Speed of enemy movement
    public int maxHealth = 10; // Maximum health of enemy
    public int damage = 2; // Amount of damage enemy inflicts on player

    private int currentHealth; // Current health of enemy
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; // Set current health to max health
    }

    // Take damage from a bullet
    public void TakeDamage()
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth); // Decrease health by the amount of damage
        if (currentHealth <= 0)
        {
            Die(); // If health reaches 0 or below, destroy the enemy
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if colliding with the player
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("collision detected");
            // Get the player's health component and apply damage
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            TakeDamage();
        }
    }

    // Destroy the enemy
    private void Die()
    {
        Destroy(gameObject);
    }
}
