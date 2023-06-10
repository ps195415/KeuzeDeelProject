using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public int size;
    public GameObject prefab;
    private Queue<GameObject> pool;

    private void Start()
    {
        pool = new Queue<GameObject>();

        for (int i = 0; i < size; i++)
        {
            GameObject bullet = GameObject.Instantiate(prefab);
            bullet.SetActive(false);
            pool.Enqueue(bullet);
        }
    }

    public GameObject GetBullet()
    {
        if (pool.Count == 0)
        {
            // If the pool is empty, create a new bullet and add it to the pool
            GameObject bullet = GameObject.Instantiate(prefab);
            bullet.SetActive(false);
            pool.Enqueue(bullet);
        }

        GameObject bulletToReturn = pool.Dequeue();
        bulletToReturn.SetActive(true);
        return bulletToReturn;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        pool.Enqueue(bullet);
    }
}
