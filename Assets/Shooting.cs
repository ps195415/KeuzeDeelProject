using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    //public GameObject bulletPartical;

    public float bulletForce = 20;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            //Instantiate(bulletPartical, transform.position, Quaternion.identity);
        }

    }

    void Shoot()
    {
        // instantiate/spawn een bullet to accses it as a gameobject 
        // Get the rigidbody from the bullet to add forece
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D _rb = bullet.GetComponent<Rigidbody2D>();
        _rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
