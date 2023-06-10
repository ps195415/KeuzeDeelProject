using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletPartical;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(bulletPartical, transform.position, transform.rotation);
            Destroy(gameObject,2);
            
        } else
        {
            Destroy(gameObject);
        }
    }

}
