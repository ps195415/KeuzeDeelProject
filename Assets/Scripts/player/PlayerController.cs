using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of player movement
    public Camera cam; // Reference to main camera
    public float bulletSpeed = 10f; // Speed of the bullet
    public float fireRate = 0.5f; // Rate of fire in seconds
    public float nextFire = 0f; // Time of the next shot
    public int poolSize = 10; // Size of the bullet pool
    public GameObject bulletPrefab; // Prefab for the bullet objecta
    public Transform bulletSpawn; // Point where the bullet will spawn

    private Rigidbody2D rb; // Reference to player's rigidbody
    private BulletPool bulletPool; // Reference to bullet pool object

    public int maxHealth = 20;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletPool = FindObjectOfType<BulletPool>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // Move player based on keyboard input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * moveSpeed;

        // Make player face towards mouse cursor
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

        // Shoot a bullet when left mouse button is pressed
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject currentBullet = bulletPool.GetBullet();
            currentBullet.transform.position = bulletSpawn.position;
            Vector2 direction = (mousePos - bulletSpawn.position).normalized;
            currentBullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        // Reset the game by reloading the current scene
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
