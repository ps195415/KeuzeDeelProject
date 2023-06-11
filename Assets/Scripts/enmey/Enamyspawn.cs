using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enamyspawn : MonoBehaviour
{
    public GameObject enemyPrefab;  // Het prefab van de vijand die gespawned moet worden
    public float spawnRate = 2f;  // Hoe vaak er een vijand gespawned moet worden (in seconden)
    public float spawnRadius = 5f;  // De maximale afstand waarbinnen vijanden gespawned kunnen worden

    private float spawnTimer;  // De teller die bijhoudt wanneer er een vijand gespawned moet worden

    private void Start()
    {
        // Begin de spawn timer
        spawnTimer = spawnRate;
    }

    private void Update()
    {
        // Tel af naar de volgende spawn
        spawnTimer -= Time.deltaTime;

        // Als de spawn timer is verstreken, spawn een vijand en reset de timer
        if (spawnTimer <= 0f)
        {
            SpawnEnemy();
            spawnTimer = spawnRate;
        }
    }

    private void SpawnEnemy()
    {
        // Bereken een willekeurige positie binnen de spawn radius
        Vector2 spawnPosition = (Random.insideUnitCircle * spawnRadius) + (Vector2)transform.position;

        // Spawn de vijand op de berekende positie
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

}

