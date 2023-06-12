using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ParticleSystem bulletEffect;

    void Awake()
    {
        FindObjectOfType<soundManager>().PlaySound("Fire");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("hit enemy");
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(20);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("hit other");
            Destroy(gameObject);
        }

        Instantiate(bulletEffect, transform.position, transform.rotation);
    }

}
