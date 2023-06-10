using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float cooldownTime = 1f;
    public float bulletSpeed = 10f;

    private bool canShoot = true;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Maak een nieuwe kogel op het vuurpunt
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Bereken de richting waarin de speler kijkt
        Vector2 shootDirection = firePoint.up;

        // Geef de kogel een snelheid in de richting van de speler
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = shootDirection * bulletSpeed;

        // Schakel de schietmogelijkheid uit gedurende de cooldowntijd
        canShoot = false;
        Invoke("EnableShooting", cooldownTime);
    }

    private void EnableShooting()
    {
        canShoot = true;
    }

}
