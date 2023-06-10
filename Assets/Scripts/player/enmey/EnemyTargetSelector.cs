using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTargetSelector : MonoBehaviour
{
    public float moveSpeed = 2f;  // De snelheid waarmee de vijand beweegt

    private Transform player;  // Referentie naar de speler

    private void Start()
    {
        // Zoek de speler op basis van de tag "Player"
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (player != null)
        {
            // Bereken de richting naar de speler
            Vector2 direction = player.position - transform.position;
            direction.Normalize();
            Vector2 movement = direction * moveSpeed * Time.deltaTime;
            transform.position += (Vector3)movement;
        }
    }
}
