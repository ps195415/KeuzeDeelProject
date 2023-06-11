using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    public int maxHealth = 100;

    public GameObject bulletPartical;

    public void TakeDamage(int damage)
    {
        Debug.Log("20 damage enemy");
        maxHealth -= damage;
        if (maxHealth == 0)
        {
            Destroy(gameObject);
            Instantiate(bulletPartical, transform.position, transform.rotation);
        }
    }


}
