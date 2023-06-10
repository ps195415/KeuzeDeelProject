using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enmey : MonoBehaviour
{
    [Header("Stats")]
    public float speed;
    public float stoppingDistance;
    public float nearDistance;
    public float startTimeBtwShots;
    private float timeBtwShots;

    [Header("References")]
    public GameObject bullet;
    public Transform target;
    public Transform firePoint;

    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position,target.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < nearDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, target.position) < stoppingDistance && Vector2.Distance(transform.position, target.position) > nearDistance)
        {
            transform.position = this.transform.position;
            ShootPlayer();
        }

        Vector2 direction = target.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    }

    void ShootPlayer()
    {
        //Debug.Log("shoot");
        if (timeBtwShots <= 0)
        {
            //Debug.Log("Demage given to Player");
            GameObject bulletOBJ = Instantiate(bullet, firePoint.position, firePoint.rotation);
            Rigidbody2D _rb = bulletOBJ.GetComponent<Rigidbody2D>();
            _rb.AddForce(transform.up * 15, ForceMode2D.Impulse);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

}
