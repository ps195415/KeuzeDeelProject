using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bSpeed = 10f;  // De snelheid van de kogel
    public int damage = 1;  // De schade die de kogel toebrengt aan vijanden
    Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Beweeg de kogel naar voren
        rb.velocity = Vector2.up * bSpeed;

        // Controleer of de kogel het scherm verlaat
        if (!IsInScreen())
        {
            // Verwijder de kogel
            Destroy(gameObject);
        }
    }

    private bool IsInScreen()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        // Controleer of de kogel zich binnen het scherm bevindt
        return screenPos.x > 0 && screenPos.x < Screen.width && screenPos.y > 0 && screenPos.y < Screen.height;
    }

    // private void OnBecameInvisible()
    // {
    //     Destroy(gameObject);
    // }
}
